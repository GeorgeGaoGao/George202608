using GeorgeWpfDLL;
using System.Windows;

namespace _25.HeroExercise
{
   
    [Hero]
    public class 段誉
    {
       
        [Skill]
        public void 六脉神剑()
        {
            MessageBox.Show($"{nameof(段誉)}施展{nameof(六脉神剑)}");
        }
        [Skill]
        public void 凌波微步()
        {
            MessageBox.Show($"{nameof(段誉)}施展{nameof(凌波微步)}");
        }

    }
    [Hero]
    public class 乔峰
    {
       
        [Skill]
        public void 降龙十八掌()
        {
            MessageBox.Show($"{nameof(乔峰)}施展{nameof(降龙十八掌)}");
        }
        [Skill]
        public void 打狗棒法()
        {
            MessageBox.Show($"{nameof(乔峰)}施展{nameof(打狗棒法)}");
        }

    }
}