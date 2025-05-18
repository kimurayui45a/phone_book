using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> phoneBook;

        public Form1()
        {
            InitializeComponent();

            // 電話帳に登録する名前一覧
            this.phoneBook = new Dictionary<string, string>();

            //this.phoneBook.Add("山田一郎", "xxx-3456-4343");
            //this.phoneBook.Add("山田二郎", "xxx-8823-9434");
            //this.phoneBook.Add("山田三郎", "xxx-7793-2117");
            //this.phoneBook.Add("山田史郎", "xxx-1693-7364");

            // data.txt からデータを読み込む
            ReadFromFile();

            foreach (KeyValuePair<string, string> data in phoneBook)
            {
                // キー（名前）を表示
                this.nameList.Items.Add(data.Key);
            }
        }

        private void ReadFromFile() 
        {
            // 確実にファイルを閉じるためにusingステートメントを使用している
            // @を先頭に付けそのままの文字列として扱う
            using (System.IO.StreamReader file =
                new System.IO.StreamReader(@"..\..\data.txt")) 
            {
                while (!file.EndOfStream) 
                {
                    string line = file.ReadLine();
                    string[] data = line.Split(',');  // 今回はdataが「,」で区切っているから
                    this.phoneBook.Add(data[0], data[1]);
                }
            }
        }

        private void NameSelected(object sender, EventArgs e)
        {
            // 選択したキー（名前）に対応する電話番号を表示する
            string name = this.nameList.Text;
            this.phoneNumber.Text = this.phoneBook[name];
        }
    }
}
