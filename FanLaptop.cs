using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace modul4_103022330051
{
    class FanLaptop
    {
        public enum FanState { QUIET, BALANCED, PERFORMANCE, TURBO };
        public enum Trigger { UP, DOWN, TURBO };

        FanState currentState = FanState.QUIET;

        class transisi
        {
            public FanState prevState;
            public FanState nextState;
            public Trigger trigger;

            public transisi(FanState prevState, FanState nextState, Trigger trigger)
            {
                this.prevState = prevState;
                this.nextState = nextState;
                this.trigger = trigger;
            }
        }

        transisi[] fans =
            {
            new transisi(FanState.QUIET, FanState.BALANCED, Trigger.UP),
            new transisi(FanState.QUIET, FanState.TURBO, Trigger.TURBO),
            new transisi(FanState.BALANCED, FanState.PERFORMANCE, Trigger.UP),
            new transisi(FanState.BALANCED, FanState.QUIET, Trigger.DOWN),
            new transisi(FanState.PERFORMANCE, FanState.TURBO, Trigger.UP),
            new transisi(FanState.PERFORMANCE, FanState.BALANCED, Trigger.DOWN),
            new transisi(FanState.TURBO, FanState.QUIET, Trigger.TURBO),
            new transisi(FanState.TURBO, FanState.PERFORMANCE, Trigger.DOWN)
        };


        public FanState getNextState(FanState prevState, Trigger trigger)
        {
            FanState nextState = prevState;

            for (int i = 0; i < fans.Length; i++)
            {
                if (fans[i].prevState == prevState && fans[i].trigger == trigger)
                {
                    nextState = fans[i].nextState;
                }
            }

            return nextState;
        }

        public void activateTrigger(Trigger trigger)
        {
            FanState nextState = getNextState(currentState, trigger);

            Console.WriteLine("Fan " + currentState + " berubah menjadi " + nextState);
            currentState = nextState;
        }

        public void Simulasi()
        {
            activateTrigger(Trigger.UP);
            activateTrigger(Trigger.UP);
            activateTrigger(Trigger.DOWN);
            activateTrigger(Trigger.DOWN);
            activateTrigger(Trigger.TURBO);
            activateTrigger(Trigger.DOWN);
        }
    }
}

