using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardApp
{
    public class BomberControl : IDisposable
    {
        private JetFighter jetFighter;

        public BomberControl(JetFighter jetFighter) => jetFighter.PlaneSpotted += JetFighter_PlaneSpotted;
        
        private void JetFighter_PlaneSpotted(object? sender, JetFighterEventArgs e)
        {
            JetFighter spottedPlane = e.SpottedPlane;
        }
        
        public void Dispose() => jetFighter.PlaneSpotted -= JetFighter_PlaneSpotted;
    }
}
