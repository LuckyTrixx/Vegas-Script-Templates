//*******************************************************************
//    Script Name: Crop16-9to4-3
//    Author: LuckyTrixx with help from https://youtu.be/nXGx0sQDlNs
//    Description: This Script crops a 16:9 VideoEvent to 4:3.
//                 !!!! ONLY WORKS, IF THE EVENT ISN'T PRE-CROPPED !!!!
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

                        VideoMotionKeyframes VidKeyframes = videoEvent.VideoMotion.Keyframes;
                        VideoMotionKeyframe firstKeyFrame = VidKeyframes[0];

                        VideoMotionBounds bounds = firstKeyFrame.Bounds;

                        bounds.TopLeft.X = (float)(0 + ((bounds.BottomRight.X*0.125)));
                        bounds.BottomLeft.X = (float)(0 + ((bounds.BottomRight.X*0.125)));
                        bounds.TopRight.X = (float)((bounds.BottomRight.X) - ((bounds.BottomRight.X*0.125)));
                        bounds.BottomRight.X = (float)((bounds.BottomRight.X) - ((bounds.BottomRight.X*0.125)));

                        firstKeyFrame.Bounds = bounds;

                    }
                }

            }

        }

    }
}