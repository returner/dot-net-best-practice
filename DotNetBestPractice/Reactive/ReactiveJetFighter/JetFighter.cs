using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveJetFighter
{
    public class JetFighter
    {
        public string Name { get; set; }

        private Subject<JetFighter> planeSpotted = new Subject<JetFighter>();

        public IObservable<JetFighter> PlaneSpotted => this.planeSpotted.AsObservable();

        //public void SpotPlane1(JetFighter jetFighter) => this.planeSpotted.OnNext(jetFighter);
        public void AllPlanesSpotted() => this.planeSpotted.OnCompleted();

        public void SpotPlane(JetFighter jetFighter)
        {
            try
            {
                if (string.Equals(jetFighter.Name, "UFO"))
                {
                    throw new Exception("UFO Found");
                }

                this.planeSpotted.OnNext(jetFighter);
            }
            catch(Exception ex)
            {
                this.planeSpotted.OnError(ex);
            }
        }
    }

    
}
