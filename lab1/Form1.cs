using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Toys> toys = new List<Toys>();               

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string file = "D:\\3 KURS\\ œœ\\lab1\\toys.txt";
                List<string> lines = File.ReadAllLines(file).ToList();
                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    Toys newToy = new Toys();
                    newToy.Name = entries[0];
                    newToy.Price = entries[1];
                    newToy.Age = entries[2];
                    newToy.Characteristic = entries[3];
                    toys.Add(newToy);
                }

                Update_ListView(toys);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var price = numericUpDown1.Value;
            List<Toys> Sort_toys = new List<Toys>();
            foreach (var toy in toys)
            {
                if (ToInt(toy.Age) <= 5 && ToInt(toy.Price) < price)
                {
                    Toys Toy = new Toys();
                    Toy.Name = toy.Name;
                    Toy.Price = toy.Price;
                    Toy.Age = toy.Age;
                    Toy.Characteristic = toy.Characteristic;
                    Sort_toys.Add(Toy);
                }
            }
            Sort_toys.Sort((x, y) => x.Price.CompareTo(y.Price));
            Update_ListView(Sort_toys);

        }
        public void Update_ListView(List<Toys> toys)
        {
            listView1.Items.Clear();
            foreach (var toy in toys)
            {
                ListViewItem item = new ListViewItem(toy.Name);
                item.SubItems.Add(toy.Price);
                item.SubItems.Add(toy.Age);
                item.SubItems.Add(toy.Characteristic);
                listView1.Items.Add(item);
            }

        }
        public int ToInt(string str)
        {
            return Convert.ToInt32(str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_ListView(toys);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}