using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveJetFighter
{
    internal class FromEventPatternSample
    {
        public event EventHandler BunnyRabbitsAttack;

        public IObservable<object> WhenBunnyRabbitsAttack
        {
            get
            {
                return Observable.FromEventPattern(h => this.BunnyRabbitsAttack += h, h => this.BunnyRabbitsAttack -= h);
            }
        }
        
    }

    class BunnyRabbitsEventArgs { 
        public BunnyRabbits BunnyRabbits { get; set; }
    }
    class BunnyRabbits { }
    class EventHandlerWrapping
    {
        public event EventHandler<BunnyRabbitsEventArgs> BunnyRabbitsAttack;

        public IObservable<BunnyRabbits> WhenBunnyRabbitsAttack
        {
            get
            {
                return Observable
                    .FromEventPattern<BunnyRabbitsEventArgs>(
                    h => this.BunnyRabbitsAttack += h,
                    h => this.BunnyRabbitsAttack -= h
                    ).Select(x => x.EventArgs.BunnyRabbits);
                    
            }
        }
    }
}
