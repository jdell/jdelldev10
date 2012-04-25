using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.lib.model
{
    public partial class Match
    {
        public Team GuestClub
        {
            get
            {
                return this.Team;
            }
            set
            {
                this.Team = value;
            }
        }
        public Team HomeClub
        {
            get
            {
                return this.Team1;
            }
            set
            {
                this.Team1 = value;
            }
        }

        public License ScoreTaker
        {
            get
            {
                return this.License;
            }
            set
            {
                this.License = value;
            }
        }
        public License Umpire1
        {
            get
            {
                return this.License1;
            }
            set
            {
                this.License1 = value;
            }
        }
        public License Umpire2
        {
            get
            {
                return this.License2;
            }
            set
            {
                this.License2 = value;
            }
        }
        public License Umpire3
        {
            get
            {
                return this.License3;
            }
            set
            {
                this.License3 = value;
            }
        }
        public License Umpire4
        {
            get
            {
                return this.License4;
            }
            set
            {
                this.License4 = value;
            }
        }
    }
}
