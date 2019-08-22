using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesignReplica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async private void OnInfoButtonClicked(object sender, EventArgs e)
        {
            string funFact = "During World War II, the cherry blossom was used to motivate the Japanese people, to stoke nationalism and militarism among the populace. Even prior to the war, they were used in propaganda to inspire Japanese spirit, as in the Song of Young Japan, exulting in warriors who were ready like the myriad cherry blossoms to scatter. In 1932, Akiko Yosano's poetry urged Japanese soldiers to endure sufferings in China and compared the dead soldiers to cherry blossoms. Arguments that the plans for the Battle of Leyte Gulf, involving all Japanese ships, would expose Japan to serious danger if they failed, were countered with the plea that the Navy be permitted to bloom as flowers of death. The last message of the forces on Peleliu was Sakura, Sakura — cherry blossoms. Japanese pilots would paint them on the sides of their planes before embarking on a suicide mission, or even take branches of the trees with them on their missions. A cherry blossom painted on the side of the bomber symbolized the intensity and ephemerality of life; in this way, the aesthetic association was altered such that falling cherry petals came to represent the sacrifice of youth in suicide missions to honor the emperor. The first kamikaze unit had a subunit called Yamazakura or wild cherry blossom. The government even encouraged the people to believe that the souls of downed warriors were reincarnated in the blossoms.";
            await DisplayAlert("Fun fact", funFact , "Ok");        
        }
    }
}