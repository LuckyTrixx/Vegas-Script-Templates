//*******************************************************************
//    Script Name: StretchToFullScreen
//    Author: LuckyTrixx
//    Description: This Script stretches all selected VideoEvents to the project-Scree-Size.
//                 (eg: 4:3 gets stretched to 16:9)
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
            foreach (Track track in myVegas.Project.Tracks)
            {
                foreach (TrackEvent trackEvent in track.Events)
                {
                    if (trackEvent.Selected && trackEvent.IsVideo())
                    {
                        VideoEvent videoEvent;

                        videoEvent = (VideoEvent)trackEvent;

                        videoEvent.VideoMotion.ScaleToFill = true;

                        videoEvent.MaintainAspectRatio = false;
                    }
                }

            }

        }

    }
}