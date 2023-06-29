using System;

namespace TicTacToe
{
    public class Player
    {
        public enum ePlayerId 
        { 
            Player1 = 1, 
            Player2, 
            Computer 
        }

        private readonly ePlayerId r_Id;
        private int m_Score;
        private string m_Name;

        internal Player(ePlayerId i_Id)
        {
            r_Id = i_Id;
            m_Score = 0;
        }

        public ePlayerId Id 
        {
            get { return r_Id; }
        }

        public int Score
        { 
            get 
            { 
                return m_Score; 
            }

            set 
            { 
                m_Score = value; 
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                if (value != string.Empty)
                {
                    m_Name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
            }
        }
    }
}
