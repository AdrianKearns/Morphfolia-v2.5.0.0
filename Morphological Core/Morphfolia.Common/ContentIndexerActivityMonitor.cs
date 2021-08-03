// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

namespace Morphfolia.Common
{
    /// <summary>
    /// Conveys general messages.
    /// </summary>
    public class GeneralContentIndexerEventArgs : EventArgs
    {
        public GeneralContentIndexerEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message;
    }

    /// <summary>
    /// Conveys progress related messages.
    /// </summary>
    public class ProgessContentIndexerEventArgs : EventArgs
    {
        public ProgessContentIndexerEventArgs(string message, int progress)
        {
            this.Message = message;
            this.Progress = progress;
        }

        public string Message;
        public int Progress;
    }



    /// <summary>
    /// The ContentIndexerActivityMonitor deals with the indexing of conent in the ABK.CMS system.
    /// It knows (by virtue of the developers understanding of the system) that it will 
    /// be dealing with text from content items - and that these are are accessed via pages.
    /// </summary>
    public class ContentIndexerActivityMonitor
    {
        /// <summary>
        /// Events are handled with delegates, so we must establish 
        /// a ContentIndexerActivityHandler as a delegate.
        /// </summary>
        public delegate void GeneralActivityHandler(object sender, GeneralContentIndexerEventArgs fe);
        public delegate void PageActivityHandler(object sender, GeneralContentIndexerEventArgs fe);
        public delegate void ContentActivityHandler(object sender, GeneralContentIndexerEventArgs fe);
        public delegate void WordActivityHandler(object sender, GeneralContentIndexerEventArgs fe);
        public delegate void DataActivityHandler(object sender, GeneralContentIndexerEventArgs fe);

        /// <summary>
        /// A public event "ContentIndexerActivityEvent" whose 
        /// type is our ContentIndexerActivityHandler delegate.
        /// </summary>
        public event GeneralActivityHandler GeneralActivityEvent;
        public event PageActivityHandler PageActivityEvent;
        public event ContentActivityHandler ContentActivityEvent;
        public event WordActivityHandler WordActivityEvent;
        public event DataActivityHandler DataActivityEvent;


        ///// <summary>
        ///// This will be the starting point of our event - it will create ContentIndexerEventArgs, 
        ///// and then raise the event, passing ContentIndexerEventArgs. 
        ///// </summary>
        ///// <param name="progress"></param>
        ///// <param name="roughWordCount"></param>
        ///// <returns></returns>
        //public string ReportContentIndexerActivity( string progress )
        //{
        //    // Now, raise the event by invoking the delegate. Pass in 
        //    // the object that initated the event (this) as well as FireEventArgs. 
        //    // The call must match the signature of FireEventHandler.
        //    return ContentIndexerActivityEvent(this, new ContentIndexerEventArgs(progress, 0));
        //}

        /// <summary>
        /// Notifies interested parties that activity is occuring at the Word level.
        /// This is the finest level of detail.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public void DataActivity(string message)
        {
            if (DataActivityEvent != null)
            {
                DataActivityEvent(this, new GeneralContentIndexerEventArgs(message));
            }
        }

        /// <summary>
        /// Notifies interested parties that activity is occuring at the Word level.
        /// This is the finest level of detail.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public void WordActivity(string message)
        {
            if (WordActivityEvent != null)
            {
                WordActivityEvent(this, new GeneralContentIndexerEventArgs(message));
            }
        }

        /// <summary>
        /// Notifies interested parties that activity is occuring at the Content level.
        /// This is a medium level of detail.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public void ContentActivity(string message)
        {
            if (ContentActivityEvent != null)
            {
                ContentActivityEvent(this, new GeneralContentIndexerEventArgs(message));
            }
        }

        /// <summary>
        /// Notifies interested parties that activity is occuring at the Page level.
        /// This is a high level of detail.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public void PageActivity(string message)
        {
            if (PageActivityEvent != null)
            {
                PageActivityEvent(this, new GeneralContentIndexerEventArgs(message));
            }
        }

        /// <summary>
        /// Notifies interested parties that activity is occuring at the Page level.
        /// This is the highest level of detail.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public void GeneralActivity(string message)
        {
            if (GeneralActivityEvent != null)
            {
                GeneralActivityEvent(this, new GeneralContentIndexerEventArgs(message));
            }
        }
    }


}
