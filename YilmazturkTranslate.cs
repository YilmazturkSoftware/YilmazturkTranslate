#region Kullanılan Paketler
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ListView = System.Windows.Forms.ListView;
#endregion

namespace YilmazturkTranslate
{
    public static class YilmazturkTranslate
    {
        #region Important / Önemli
        // TR :
          // Bu script Yılmaztürk Software için yazılmıştır.
          // Emre Yılmaztürk tarafından yazıldı.
          // Bu kod sadece C# Forms'ta çalışır. Console'da çalışamaz.
        #endregion
        #region Main Void / Ana Void
        public static void Translate(Control control)
        {
            string combinedString = string.Join(", ", ListControlItems(control, 0));

            string input = combinedString;
            string delimiter = ", ";
            int startIndex = 0;
            int commaIndex;

            while ((commaIndex = input.IndexOf(delimiter, startIndex)) != -1)
            {
                string part = input.Substring(startIndex, commaIndex - startIndex);
                TranslateObjects(GetControlByName(control, part));

                startIndex = commaIndex + delimiter.Length;
            }

            string lastPart = input.Substring(startIndex);
            TranslateObjects(GetControlByName(control,lastPart));
         

        }
        #endregion
        #region Translate Objects / Objeleri Çevirme
        public static void TranslateObjects(Control control)
        {
            if(control is Label label)
            {
                if (translateMainLanguage.Contains(label.Text))
                {
                    int index = translateMainLanguage.IndexOf(label.Text);
                    label.Text = translateOtherLanguage[index];
                }  
            }
            else if (control is Button button)
            {
                if (translateMainLanguage.Contains(button.Text))
                {
                    int index = translateMainLanguage.IndexOf(button.Text);
                    button.Text = translateOtherLanguage[index];
                }
            }
            else if (control is CheckBox checkBox)
            {
                if (translateMainLanguage.Contains(checkBox.Text))
                {
                    int index = translateMainLanguage.IndexOf(checkBox.Text);
                    checkBox.Text = translateOtherLanguage[index];
                }

            }
            else if (control is LinkLabel linkLabel)
            {
                if (translateMainLanguage.Contains(linkLabel.Text))
                {
                    int index = translateMainLanguage.IndexOf(linkLabel.Text);
                    linkLabel.Text = translateOtherLanguage[index];
                }

            }
            else if (control is ListBox listBox)
            {
                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    string itemText = listBox.Items[i].ToString();

                    if (translateMainLanguage.Contains(itemText))
                    {
                        int index = translateMainLanguage.IndexOf(itemText);
                        listBox.Items[i] = translateOtherLanguage[index];
                    }

                    
                }
            }
           
            else if (control is System.Windows.Forms.ComboBox comboBox)
            {
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    string itemText = comboBox.Items[i].ToString();

                    if (translateMainLanguage.Contains(itemText))
                    {
                        int index = translateMainLanguage.IndexOf(itemText);
                        comboBox.Items[i] = translateOtherLanguage[index];
                    }


                }
            }
            else if (control is CheckedListBox checkedListBox)
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    string itemText = checkedListBox.Items[i].ToString();

                    if (translateMainLanguage.Contains(itemText))
                    {
                        int index = translateMainLanguage.IndexOf(itemText);
                        checkedListBox.Items[i] = translateOtherLanguage[index];
                    }


                }
            }
            else if (control is RadioButton radioButton)
            {
                if (translateMainLanguage.Contains(radioButton.Text))
                {
                    int index = translateMainLanguage.IndexOf(radioButton.Text);
                    radioButton.Text = translateOtherLanguage[index];
                }
            }

        }
        #endregion

        // TRANSLATING - ÇEVİRME İŞLEMİ
        // TR - Çevirmeleri buraya yazın. Diğer kodlar bu çevirme işleminin çalışması içindir. Eğer istemediğiniz bir kod varsa silebilir ve ya ekleme yapabilirsiniz.
        // EN - Write translates.
        static List<string> translateMainLanguage = new List<string> {
            "MERHABA",
            "DÜNYA"
            };
        static List<string> translateOtherLanguage = new List<string> {
            "HELLO",
            "WORLD"
            };

        #region Other Voids / Diğer Fonksiyonlar

        static List<string> itemsList = new List<string>();

        private static Control GetControlByName(Control control,string controlName)
        {
            return control.Controls.Find(controlName, true)?.FirstOrDefault();
        }

        private static List<string> ListControlItems(Control control, int indentLevel = 0)
        {


            System.Windows.Forms.ComboBox combo = new System.Windows.Forms.ComboBox();
            combo.Items.Add(control.Name);
  

            foreach (object item in combo.Items)
            {
                itemsList.Add(item.ToString());
            }

            foreach (Control subControl in control.Controls)
            {
                ListControlItems(subControl, indentLevel + 1);
            }
            return itemsList;
            
        }

        #endregion
    }
}
