using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Effects.Effects
{
    public class EntryEffect : RoutingEffect
    {
        public EntryEffect() : base($"MyCompany.{nameof(EntryEffect)}")
        {
        }
    }
}
