//*******************************************************************
//    Script Name: BulkEffectApply
//    Author: LuckyTrixx with help from https://youtu.be/WDhVz5RHz_0
//    Description: This Script puts a predefined Effect with a predefined
//                 preset on every selected VideoEvent.
//    Usage: Change Line 23 and Line 25 according to your needs.
//           If you need help figuring out the effect/preset names: Check out this Video: https://youtu.be/Dx4jZ1o9qbQ
//*******************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using ScriptPortal.Vegas;

namespace LuckyClass
{
    public class EntryPoint
    {
        public void FromVegas (Vegas myVegas)
        {
            //Name of the Effect you want to apply
            string fxName = "CHANGE ME";
            //Name of the Effect preset you want to apply
            string presetName = "CHANGE ME";

            foreach (Track track in myVegas.Project.Tracks)
            {
                foreach (TrackEvent trackEvent in track.Events)
                {
                    if (trackEvent.Selected && trackEvent.IsVideo())
                    {
                        //I don't know why, but adding the Effect to multiple selected Events only works,
                        //if I have the following declarations here.
                        PlugInNode fxList = myVegas.VideoFX;
                        PlugInNode fxChild = fxList.GetChildByName(fxName);
                        Effect effect = new Effect(fxChild);
                        VideoEvent videoEvent;

                        videoEvent = (VideoEvent)trackEvent;
                        videoEvent.Effects.Add(effect);
                        effect.Preset = presetName;
                    }
                }

            }

        }

    }
}
