using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardApp
{

    public class JetFighter
    {
        public event EventHandler<JetFighterEventArgs> PlaneSpotted;

        public void SpotPlane(JetFighter jetFighter)
        {
            EventHandler<JetFighterEventArgs> eventHandler = this.PlaneSpotted;
            if (eventHandler != null)
            {
                eventHandler(this, new JetFighterEventArgs(jetFighter));
            }
        }
    }
}
