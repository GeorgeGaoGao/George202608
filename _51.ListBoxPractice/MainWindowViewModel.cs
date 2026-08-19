using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _51.ListBoxPractice
{
    public class MainWindowViewModel:ObservableObject
    {
        public ObservableCollection<Sentence> Poetries { get; set; }=new ObservableCollection<Sentence>();
        public MainWindowViewModel()
        {
            Poetries.Add(new Sentence() { Content= "绝句 唐·杜甫 两个黄鹂鸣翠柳，一行白鹭上青天。窗含西岭千秋雪，门泊东吴万里船。" });
            Poetries.Add(new Sentence() { Content= "早发白帝城 唐·李白 朝辞白帝彩云间，千里江陵一日还。两岸猿声啼不住，轻舟已过万重山。" });
            Poetries.Add(new Sentence() { Content= "游园不值 宋·叶绍翁 应怜屐齿印苍苔，小扣柴扉久不开。春色满园关不住，一枝红杏出墙来。" });
            Poetries.Add(new Sentence() { Content= "山行 唐·杜牧 远上寒山石径斜，白云生处有人家。停车坐爱枫林晚，霜叶红于二月花。" });
            Poetries.Add(new Sentence() { Content= "望庐山瀑布 唐·李白 日照香炉生紫烟，遥看瀑布挂前川。飞流直下三千尺，疑是银河落九天。" });
            Poetries.Add(new Sentence() { Content= "咏柳 唐·贺知章 碧玉妆成一树高，万条垂下绿丝绦。不知细叶谁裁出，二月春风似剪刀。" });
           
        }

    }
}
