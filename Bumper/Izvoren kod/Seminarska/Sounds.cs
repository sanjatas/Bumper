using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Seminarska
{
    class Sounds
    {
        public SoundPlayer prefrlanje;
        public SoundPlayer levelup;
        public SoundPlayer gameOver;
        public Sounds()
        {
            gameOver = new SoundPlayer(Properties.Resources.Whimper_SoundBible_com_1729765971);
            prefrlanje = new SoundPlayer(Properties.Resources.Woosh_Mark_DiAngelo_4778593);
            levelup = new SoundPlayer(Properties.Resources.Power_Up_Ray_Mike_Koenig_800933783);
        }
    }
}
