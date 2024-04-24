// Lewis Cottrill
// 18/04//2024
// C# AT2

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AT2_Wiki_App
{
    public partial class DataForm : Form // Declare a public partial class DataForm, which inherits from the Form class
    {
        private List<DataItem> allItems; // I create a List of objects from class DataItem, the list is called allItems
        private bool userSelection; // I create bool
        private bool isEditing; // I create bool
        private DataItem selectedItem; // I create a DataItem (class) selectedItem (instance) 
        private List<RadioButton> radioButtons; // I create a List of objects from RadioButton, the list is called radioButtons
        public DataForm() // Constructor for DataForm class
        {
            InitializeComponent(); 
            allItems = new List<DataItem>(); // When allItems called, create a new List of DataItems objects
            LoadDataFromFile("codingTerms.txt"); // Temporary .txt file location specified 
            sortButton.Click += sortButton_Click;
            userSelection = true;
            isEditing = false;
            selectedItem = null;
            listView.Columns.Add("Term", 150);
            listView.Columns.Add("Catagory", 150);
            listView.Columns.Add("Structure", 150);
            listView.Columns.Add("Definition", 300);
            radioButtons = new List<RadioButton> {linearButton, nonLinearButton}; // When radioButtons called, create a new list of RadioButton objects, the list is initialized with 2 elements
            try // Try to load catagories from the catagories.txt file 
            {
                string[] categories = System.IO.File.ReadAllLines("categories.txt"); // Read all lines, the string catagories is now an array of items from the .txt file
                foreach (string category in categories) // For every catagory in catagories
                {
                    categoryComboBox.Items.Add(category); // Add category to combobox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // If error
            }
        }
        public bool CheckForDuplicate(string term) // Method for checking for duplicates, takes parameter term
        {
            return allItems.Exists(item => item.Term.ToLower() == term.ToLower()); // Call the exists method on the allitems list, checks if the term property, ignoring case, is equal to the parameter, also ignoring case. 
        }
        protected override void OnDoubleClick(EventArgs e) // When double click on grey space
        {
            base.OnDoubleClick(e);
            linearButton.Checked = false; // Clear all boxes
            nonLinearButton.Checked = false;
            categoryComboBox.SelectedIndex = -1; // Clear category combobox
            LoadDataFromFile("codingTerms.txt"); // Reset the listview by reloading temporary .txt
            definitionTextBox.Clear(); // Clear box
            nameTextBox.Clear(); // Clear box
            searchTextBox.Clear(); // Clear box
            SaveDataToFile("codingTerms.txt"); // Call save method to temporary .txt file
        }
        
        private void LoadDataFromFile(string filePath) // Load data from temporary .txt file
        {
            listView.Items.Clear();
            allItems.Clear();
            selectedItem = null;
            try
            {
                using (StreamReader sr = new StreamReader(filePath)) // Using StreamReader
                {
                    string line; // Declare a string to hold each line of the file
                    while ((line = sr.ReadLine()) != null) // While loop to read until null is returned
                    {
                        string[] columns = line.Split('\t'); // Declare an array of strings called columns, split the string line into substrings whenever encountering \t space, resulting in an array of substrings stored in columns variable 
                        if (columns.Length >= 4) // If columns greater than or equal to 4 
                        {
                            DataItem item = new DataItem(columns[0], columns[1], columns[2], columns[3]); // Create a new DataItem object called item, assign it the first 4 columns of the array as its data
                            listView.Items.Add(new ListViewItem(new string[] { item.Term, item.Category, item.Structure, item.Definition })); // Create a new array of strings with 4 elements, properties of the item object, which is an instance of the DataItem class
                            allItems.Add(item); // add the item object to the allItems collection
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // If error
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = searchTextBox.Text.ToLower(); // declare string searchTerm, give it value of searchTextBox text, convert to lower case. 
            listView.Items.Clear(); // Clear items in listView
            foreach (var item in allItems) // For each item in allItems
            {
                if (item.Term.ToLower().Contains(searchTerm)) // Checks to see if there a matching item.Term ignoring case
                {
                    listView.Items.Add(new ListViewItem(new string[] { item.Term, item.Category, item.Structure, item.Definition })); // Adds only the items that match the search into the listView
                }
            }
        }
        private void linearButton_CheckedChanged(object sender, EventArgs e)
        {
            if (linearButton.Checked && selectedItem == null) // If linearButton checked but no item selected
            {
                    FilterListView("Linear", categoryComboBox.SelectedItem?.ToString()); // Perform filtration function 
            }
        }
        private void nonLinearButton_CheckedChanged(object sender, EventArgs e)
        {
            if (nonLinearButton.Checked && selectedItem == null) // If nonLinearButton checked but no item selected
            {
                    FilterListView("Non-Linear", categoryComboBox.SelectedItem?.ToString()); // Perform filtration function 
            }
        }
        private void FilterListView(string structureType, string category) // Declare method FilterListView, takes 2 parameters structureType and category
        {
            userSelection = false; // Gives userSelection bool value of false
            listView.Items.Clear(); // Clear listView
            foreach (var item in allItems) // For each item in allItems
            {
                if ((string.IsNullOrEmpty(structureType) || item.Structure == structureType) && // Checks if structureType is null or empty, return true if true, then check if the structure property of the object item is equal to the structureType 
                    (string.IsNullOrEmpty(category) || item.Category == category)) // And checks if category is null or empty, return true if true, then check if the category property of the object item is equal to the category
                {
                    ListViewItem listViewItem = new ListViewItem(item.Term); // Declare listViewItem of ListViewItem, pass the Term property of the item object to the ListViewItem constructor. 
                    listViewItem.SubItems.Add(item.Category); // Add new subItems to listViewItem
                    listViewItem.SubItems.Add(item.Structure);
                    listViewItem.SubItems.Add(item.Definition);
                    listView.Items.Add(listViewItem); // Adds the listViewItem to the listView
                }
            }
            userSelection = true; // Bool userSelection is now true
        }
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isEditing && listView.SelectedItems.Count == 0) // if isEditing false and no item selected in listView
            {
                if (categoryComboBox.SelectedItem != null) // If an item is selected in the combobox
                {
                    string structureType = linearButton.Checked ? "Linear" : nonLinearButton.Checked ? "Non-Linear" : ""; // string structureType has value of either linear or non-linear
                    FilterListView(structureType, categoryComboBox.SelectedItem.ToString()); // Calls FilterListView method, with structureType and comboBox selected item as arguments
                }
                else
                {
                    LoadDataFromFile("codingTerms.txt"); // Reset the listView
                }
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveDataToFile("codingTerms.txt"); // Call save method on temporary .txt file
            SaveDataToDatFile(); // Call proper save method
        }
        private void SaveDataToDatFile() // Method for saving to .dat
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // Call new saveFileDialog
            saveFileDialog.Filter = "DAT files (*.dat)|*.dat"; // Filter only .dat
            saveFileDialog.Title = "Save Data";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) // If successfully navigated save file dialog
            {
                try
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Create))) // Using binary writer, create save file
                    {
                        foreach (DataItem item in allItems) // For each DataItem item in allItems
                        {
                            writer.Write(string.Join("\t", new string[] { item.Term, item.Category, item.Structure, item.Definition })); // Write to .dat in tab space 2D array
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // If error
                }
            }
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadDataFromDatFile(); // Call load from .dat method
            SaveDataToFile("codingTerms.txt"); // Call save method on temporary .txt to update
        }
        private void LoadDataFromDatFile() // Load from .dat method
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // Create new openFileDialog 
            openFileDialog.Filter = "DAT files (*.dat)|*.dat"; // Filter .dat
            openFileDialog.Title = "Load Data";
            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(openFileDialog.FileName, FileMode.Open))) // Call BinaryReader to read file
                    {
                        listView.Items.Clear(); // Clear listView
                        allItems.Clear(); // Clear allItems list
                        selectedItem = null; // selectedItem is null
                        while (reader.BaseStream.Position != reader.BaseStream.Length) // Loop to read until the current position does not equal length
                        {
                            string line = reader.ReadString(); // Create string line, give it value of read string line
                            string[] columns = line.Split('\t'); // Create an array of columns, give it read string line, split the columns by tab space
                            if (columns.Length >= 4) // If columns greater or equal to 4 
                            {
                                DataItem item = new DataItem(columns[0], columns[1], columns[2], columns[3]); // Create new DataItem object, called item, give it the 4 columns read from the file
                                ListViewItem listViewItem = new ListViewItem(new string[] { item.Term, item.Category, item.Structure, item.Definition }); // Create new ListViewItem object, create a new string array and pass it the 4 elements of the item object
                                listView.Items.Add(listViewItem); // Add the listViewItem to the listView
                                allItems.Add(item); // Add the item to allItems
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // If error
                }
            }
        }
        private void addButton_Click(object sender, EventArgs e) // Add button method
        {
            if (listView.SelectedItems.Count == 0) // If nothing selected in listView
            {
                string name = nameTextBox.Text; // Create string name, give it value of nameTextBox text
                if (CheckForDuplicate(name)) // If duplicate found, with argument of name from nameTextBox.
                {
                    MessageBox.Show("A term with this name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Inform
                    return;
                }
                string definition = definitionTextBox.Text; // String definition given value of definitionTextBox text
                string structure = linearButton.Checked ? "Linear" : nonLinearButton.Checked ? "Non-Linear" : ""; // String structure given value of linear or non-linear
                string category = categoryComboBox.SelectedItem?.ToString(); // String catagory is value of selected item in combobox
                DataItem item = new DataItem(name, category, structure, definition); // Create new instance of DataItem called item, give it 4 parameters
                listView.Items.Add(new ListViewItem(new string[] { item.Term, item.Category, item.Structure, item.Definition })); // Create a new ListViewItem with the values of item object as an array of strings, add it to the listView
                allItems.Add(item); // Add item to allItems
                SaveDataToFile("codingTerms.txt"); // Call save method
            }
        }
        private void editButton_Click(object sender, EventArgs e) // Edit button method
        {
            if (listView.SelectedItems.Count > 0) // If something selected in listView
            {
                isEditing = true; // isEditing has value of true
                ListViewItem selectedListViewItem = listView.SelectedItems[0]; // selectedListViewItem becomes the user selected item
                DataItem selectedItem = allItems[listView.SelectedItems[0].Index]; // selectedItem becomes the user selected item
                selectedItem.Term = nameTextBox.Text; // Term becomes the nameTextBox text
                selectedItem.Category = categoryComboBox.SelectedItem.ToString(); // Catagory becomes the catagory selected in combobox
                selectedItem.Definition = definitionTextBox.Text; // Definition becomes the definition in definitionTextBox
                if (linearButton.Checked)
                {
                    selectedItem.Structure = "Linear"; // If linear button checked, selectedItem structure becomes linear
                }
                else if (nonLinearButton.Checked)
                {
                    selectedItem.Structure = "Non-Linear"; // If non-linear button checked, selectedItem structure becomes non-linear
                }

                foreach (DataItem item in allItems) // For each item in allItems
                {
                    if (item == selectedItem) // If item is the selectedItem
                    {
                        item.Category = selectedItem.Category; // Makes changes if necessary 
                        item.Definition = definitionTextBox.Text; // Makes changes if necessary 
                        item.Structure = selectedItem.Structure; // Makes changes if necessary 
                        break;
                    }
                }
                listView.Items.Remove(selectedListViewItem); // Remove the currently selected item
                ListViewItem listViewItem = new ListViewItem(new string[] { selectedItem.Term, selectedItem.Category, selectedItem.Structure, selectedItem.Definition }); // Create new listViewItem with the new parameters
                listView.Items.Add(listViewItem); // Add the new listViewItem
                SaveDataToFile("codingTerms.txt"); // Save to temporary .txt
                LoadDataFromFile("codingTerms.txt"); // Load from temporary .txt
                definitionTextBox.Clear(); // Clear
                nameTextBox.Clear(); // Clear
                searchTextBox.Clear(); // Clear
            }
        }
        private void SaveDataToFile(string filePath) // Save data to temporary .txt
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath)) // Create new StreamWriter with filepath
                {
                    foreach (DataItem item in allItems) // For each DataItem item in allItems
                    {
                        sw.WriteLine(string.Join("\t", new string[] { item.Term, item.Category, item.Structure, item.Definition })); // Write to file in 2D array with tab spaces
                    }
                }
                isEditing = false; // isEditing becomes false
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // If error
            }
        }
        private void deleteButton_Click(object sender, EventArgs e) // Delete button method
        {
            if (listView.SelectedItems.Count > 0) // If something selected in listView
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) // Prompt user if they want to proceed
                {
                    ListViewItem selectedItem = listView.SelectedItems[0]; // the selectedItem becomes the user selected item
                    listView.Items.Remove(selectedItem); // Remove selectedItem from listView
                    DataItem itemToRemove = allItems.FirstOrDefault(item => item.Term == selectedItem.Text); // DataItem itemToRemove is given value of the first element in the sequence, it checks if item.term is equal to selectedItem.Text
                    if (itemToRemove != null) // If itemToRemove is not null
                    {
                        allItems.Remove(itemToRemove); // Remove itemToRemove from allItems
                    }
                    SaveDataToFile("codingTerms.txt"); // Save to temporary .txt file
                }
            }
        }
        private void definitionTextBox_TextChanged(object sender, EventArgs e)
        {
        }
        private void listView_SelectedIndexChanged(object sender, EventArgs e) // listView method
        {
            if (listView.SelectedItems.Count > 0 && userSelection) // If there is an item selected and userSelection true
            {
                ListViewItem selectedListViewItem = listView.SelectedItems[0]; // selectedListViewItem becomes user selection 
                selectedItem = allItems.FirstOrDefault(item => item.Term == selectedListViewItem.Text); // selectedItem is given value of the first element in the sequence, it checks if item.term is equal to selectedListViewItem
                string category = selectedListViewItem.SubItems[1].Text; // string category is given value of selectedListViewItem subitem 1 (category)
                int index = categoryComboBox.FindStringExact(category); // int index becomes the index of the category in the combobox
                if (index != -1) // If index is not -1
                {
                    categoryComboBox.SelectedIndex = index; // SelectedIndex becomes int index
                }
                string structureType = listView.SelectedItems[0].SubItems[2].Text; // string structureType becomes the user selected items subitem 2 (structure)
                int radioButtonIndex = structureType == "Linear" ? 0 : 1; // int radioButtonIndex becomes structure type with value of either 1 or 0 depending if it matches with 'linear'
                radioButtons[radioButtonIndex].Checked = true; // Automatically check a radio button depending on structureType of item
                if (listView.SelectedItems[0].SubItems.Count > 3) // Checks if selectedItem in listView has more than 3 subitems
                {
                    string definition = listView.SelectedItems[0].SubItems[3].Text; // string definition becomes selectedItem subitem 3 (definition) 
                    definitionTextBox.Text = definition; // Fill definitionTextBox with definition 
                }
                string name = listView.SelectedItems[0].SubItems[0].Text; // string name is selectedItems first subitem (name) 
                nameTextBox.Text = name; // nameTextBox contains name
            }
            else
            {
                selectedItem = null; // selectedItem becomes null
            }
        }
        private void DataDisplayLoad(object sender, EventArgs e)
        {
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
        }
        private void sortButton_Click(object sender, EventArgs e)
        {
            allItems.Sort(); // Call inbuilt sort function
            listView.Items.Clear(); // Clear listView
            foreach (var item in allItems) // for each item in allItems
            {
                listView.Items.Add(new ListViewItem(new string[] { item.Term, item.Category, item.Structure, item.Definition })); // Create new listViewItem with the new parameters
            }
        }
    }
}


