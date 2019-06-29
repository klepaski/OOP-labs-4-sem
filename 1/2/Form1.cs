using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public delegate bool Comparator(object first, object second);///опр. пор.сортировки
        private Comparator algo;

        public void Sort()
        {
            for (int i = 0; i < listBox1.Items.Count; ++i)
                for (int j = i + 1; j < listBox1.Items.Count; ++j)
                {
                    if (algo(listBox1.Items[i], listBox1.Items[j]))
                    {
                        object temp = listBox1.Items[i];
                        listBox1.Items[i] = listBox1.Items[j];
                        listBox1.Items[j] = temp;
                    }
                }
        }



        private void button1_Click(object sender, EventArgs e)  ///СГЕНЕРИРОВАТЬ КОЛЛЕКЦИЮ
        {
            if (Int32.TryParse(textBox1.Text, out int count))
            {
                listBox1.Items.Clear();
                Random random = new Random();
                for (int i = 0; i < count; ++i)
                    listBox1.Items.Add(random.Next(100));
            }
        }



        private void button2_Click(object sender, EventArgs e)  ///СОРТ ПО ВОЗРАСТАНИЮ
        {
            algo = (object first, object second) => (Int32)first > (Int32)second;
            Sort();
        }

        private void button3_Click(object sender, EventArgs e)  ///СОРТ ПО УБЫВАНИЮ
        {
            algo = (object first, object second) => (Int32)first < (Int32)second;
            Sort();
        }






        private void button4_Click(object sender, EventArgs e)  ///ЗАПРОС 1 (>50)
        {
            IEnumerable<int> result = listBox1.Items.Cast<int>().Where(x => x > 50);
            listBox2.Items.Clear();
            foreach(int item in result)
                listBox2.Items.Add(item);
        }

        private void button5_Click(object sender, EventArgs e)  ///ЗАПРОС 2 (30 < x < e60
        {
            IEnumerable<int> result = listBox1.Items.Cast<int>().Where(x => x >= 30 && x <= 60).OrderBy(x=>x);
            listBox2.Items.Clear();
            foreach (int item in result)
                listBox2.Items.Add(item);
        }

        private void button6_Click(object sender, EventArgs e)  ///ЗАПРОС 3 (>=60)
        {
            IEnumerable<int> result = listBox1.Items.Cast<int>().Where(x => x >= 60).OrderByDescending(x => x);
            listBox2.Items.Clear();
            foreach (int item in result)
                listBox2.Items.Add(item);
        }
    }
}