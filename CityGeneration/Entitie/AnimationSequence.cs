using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGeneration.Entitie
{
    class AnimationSequence
    {
        private int _numberOfFrames;

        private float _timePerFrame;

        private int _startRow;
        private int _startColumn;

        /// <summary>
        /// Holder for defined animations
        /// </summary>
        /// <param name="NumberOfFrames"></param>
        /// <param name="TimePerFrame"></param>
        /// <param name="StartRow"></param>
        /// <param name="StartColumn"></param>
        public AnimationSequence(int StartRow, int StartColumn, int NumberOfFrames, float TimePerFrame)
        {
            _numberOfFrames = NumberOfFrames;
            _timePerFrame = TimePerFrame;
            _startRow = StartRow;
            _startColumn = StartColumn;
        }

        public int NumberOfFrames
        {
            get { return _numberOfFrames; }
        }

        public float TimePerFrame
        {
            get { return _timePerFrame; }
        }

        public int StartRow
        {
            get { return _startRow; }
        }

        public int StartColumn
        {
            get { return _startColumn; }
        }
    }
}
