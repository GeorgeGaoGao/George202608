using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace _26.HeroDll
{
    [Hero]
    public class 丁春秋
    {
        [Skill]
        public void 吸星大法()
        {
            MessageBox.Show($"{nameof(丁春秋)}施展{nameof(吸星大法)}");
        }
       
    }
}
