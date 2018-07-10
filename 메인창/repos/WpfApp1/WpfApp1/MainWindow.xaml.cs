using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    NameAdds nameadds;
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nameadds = new NameAdds();
            nameadds = (NameAdds)FindResource("names");
        }
        private void insertbutton_Click(object sender, RoutedEventArgs e)
        {
            nameadds.Add(new NameAdd(txtName.Text, txtAddress.Text));
        }
    }
    public class NameAdds : ObservableCollection<NameAdd> { }
    public class NameAdd : INotifyPropertyChanged

    {

        // INotifyPropertyChanged 인터페이스 멤버

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string strName)

        {

            if (PropertyChanged != null)

            {

                PropertyChanged(this, new PropertyChangedEventArgs(strName));

            }

        }



        string name = string.Empty;

        public string Name

        {

            get { return name; }

            set

            {

                name = value;

                Notify("Name");

            }

        }



        string add = string.Empty;

        public string Add

        {

            get { return add; }

            set

            {

                add = value;

                Notify("Add");

            }

        }



        public NameAdd() : this("이름입력", "주소입력") { }

        public NameAdd(string name, string add)

        {

            this.name = name;

            this.add = add;

        }

    }
}
