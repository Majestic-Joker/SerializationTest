using System.Text.Json;

namespace Serialization_Test
{
    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();
            //CreateItemHolder();

            ItemHolder? itemHolder = LoadItemHolder();

            if( itemHolder != null ) {
                label1.Text = itemHolder.Items[2].Description;
            }
        }

        public void CreateItemHolder() {
            var itemHolder = new ItemHolder{
                Name = "First Item Holder",
                Description = "An item holder is a list of items with extra info. Hey look we changed the description",
                Date = DateTime.Now,
                Items = new List<ListItem>{ new ListItem{
                        Name = "Item Uno",
                        Value = 11,
                        Description = "This list item is a bunch of uno cards",
                        Date = DateTime.Parse("2019-08-01")
                    },
                    new ListItem{
                        Name = "Second Item",
                        Value = 420,
                        Description = "The 2nd item is weed",
                        Date = DateTime.Parse("2023-04-20")
                    },
                    new ListItem{
                        Name = "Third",
                        Value = 15,
                        Description = "Cd items, with cover art",
                        Date = DateTime.Parse("2012-12-12")
                    }
                }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            
            string json = JsonSerializer.Serialize(itemHolder, options);

            string assignmentName = "ItemHolderTest1"; //whatever the user enters

            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SerializationTest");
            folderPath = Path.Combine(folderPath, assignmentName);
            Directory.CreateDirectory(folderPath);

            string temp = Path.Combine(folderPath, $"{assignmentName}.json");

            File.WriteAllText(temp, json);
        }

        public ItemHolder? LoadItemHolder(){
            ItemHolder? itemHolder = null;

            //Open file dialog to choose file
            OpenFileDialog dialog = new OpenFileDialog();

            if(dialog.ShowDialog() == DialogResult.OK){
                string filepath = dialog.FileName;    

                var fileStream = dialog.OpenFile();
                var reader = new StreamReader(fileStream);

                string json = reader.ReadToEnd();
                itemHolder = JsonSerializer.Deserialize<ItemHolder>(json);
            }

            return itemHolder;
        }
    }
}