using System;

namespace TicTacToe
{
    public class Game
    {
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayerTurn;
        private Player m_GameWinner;

        public Game(int i_BoardSize, bool i_IsTwoPlayerGame)
        {
            Player.ePlayerId player2Id = i_IsTwoPlayerGame ? Player.ePlayerId.Player2 : Player.ePlayerId.Computer;

            m_Board = new Board(i_BoardSize);
            m_Player1 = new Player(Player.ePlayerId.Player1);
            m_Player2 = new Player(player2Id);
            m_CurrentPlayerTurn = m_Player1;
            m_GameWinner = null;
        }

        public Player Winner
        {
            get
            {
                return m_GameWinner;
            }  
        }

        public Player CurrentPlayerTurn
        {
            get
            {
                return m_CurrentPlayerTurn;
            }
        }

        public int BoardSize
        {
            get
            {
                return m_Board.Size;
            }
        }

        public int Player1Score
        {
            get
            {
                return m_Player1.Score;
            }
        }

        public int Player2Score
        {
            get
            {
                return m_Player2.Score;
            }
        }

        public string Player1Name
        {
            get
            {
                return m_Player1.Name;
            }

            set 
            {
                m_Player1.Name = value;
            }
        }

        public string Player2Name
        {
            get
            {
                return m_Player2.Name;
            }

            set
            {
                m_Player2.Name = value;
            }
        }

        public Board.eSquareValue GetSignByCoordinates(int i_X, int i_Y)
        {
            return m_Board.GetSquareValue(i_X, i_Y);
        }

        public bool IsComputerTurn()
        {
            return m_CurrentPlayerTurn.Id == Player.ePlayerId.Computer;
        }

        public void InitGame()
        {
            m_Board.ClearBoard();
            m_CurrentPlayerTurn = m_Player1;
            m_GameWinner = null;
        }

        public bool MarkSquare(int i_X, int i_Y)
        {
            Board.eSquareValue sign = convertEPlayerToESquareValue(m_CurrentPlayerTurn);
            bool successMark = m_Board.MarkSquare(i_X, i_Y, sign);

            if (successMark)
            {      
                switchBetweenCurrentPlayerTurn();
                if (isSequence(i_X, i_Y))
                {
                    m_GameWinner = m_CurrentPlayerTurn;
                    m_GameWinner.Score++;
                }
            }

            return successMark;
        }

        public void PlayAsComputer(out int o_ComputerX, out int o_ComputerY)
        {
            int x, y;
            Random rand = new Random();
            bool succeedToMark;

            do
            {
                x = rand.Next(m_Board.Size);
                y = rand.Next(m_Board.Size);
                succeedToMark = MarkSquare(x, y);
            } while (!succeedToMark);

            o_ComputerX = x;
            o_ComputerY = y;
        }


        public bool IsGameOver()
        {
            return m_Board.AreAllSquaresMarked() || hasWinner();
        }

        public bool IsDraw()
        {
            return m_Board.AreAllSquaresMarked() && !hasWinner();
        }

        private void switchBetweenCurrentPlayerTurn()
        {
            bool isCurrentPlayerIsOne = m_CurrentPlayerTurn == m_Player1;

            m_CurrentPlayerTurn = isCurrentPlayerIsOne ? m_Player2 : m_Player1;
        }

        private Board.eSquareValue convertEPlayerToESquareValue(Player i_Player)
        {
            Board.eSquareValue res;

            if (i_Player.Id == Player.ePlayerId.Player1)
            {
                res = Board.eSquareValue.Player1;
            }
            else
            {
                res = Board.eSquareValue.Player2;
            }

            return res;
        }
       
        private bool hasWinner()
        {
            return m_GameWinner != null;
        }

        private bool isSequence(int i_X, int i_Y)
        {
            return checkSequenceInDiagonal() || checkAntiDiagonal() || checkSequenceInRow(i_X) || checkSequenceInColumn(i_Y);
        }

        private bool checkSequenceInRow(int i_Row) 
        {
            Board.eSquareValue sign = m_Board.GetSquareValue(i_Row, 0);
            bool isAllRowTheSameSign = (sign != Board.eSquareValue.Empty);

            for (int i = 0; i < m_Board.Size; i++)
            {
                if (m_Board.GetSquareValue(i_Row, i) != sign)
                {
                    isAllRowTheSameSign = false;
                }
            }

            return isAllRowTheSameSign;
        }

        private bool checkSequenceInColumn(int i_Col)
        {
            Board.eSquareValue sign = m_Board.GetSquareValue(0, i_Col);
            bool isAllColumnTheSameSign = (sign != Board.eSquareValue.Empty);

            for (int i = 0; i < m_Board.Size; i++)
            {
                if (m_Board.GetSquareValue(i, i_Col) != sign)
                {
                    isAllColumnTheSameSign = false;
                }
            }

            return isAllColumnTheSameSign;
        }

        private bool checkSequenceInDiagonal()
        {
            Board.eSquareValue sign = m_Board.GetSquareValue(0, 0);
            bool isAllDiagTheSameSign = (sign != Board.eSquareValue.Empty);

            for (int i = 0; i < m_Board.Size; i++)
            {
                if (m_Board.GetSquareValue(i, i) != sign)
                {
                    isAllDiagTheSameSign = false;
                }
            }

            return isAllDiagTheSameSign;
        }

        private bool checkAntiDiagonal()
        {
            Board.eSquareValue sign = m_Board.GetSquareValue(0, m_Board.Size - 1);
            bool isAllDiagTheSameSign = (sign != Board.eSquareValue.Empty);

            for (int i = 0; i < m_Board.Size; i++)
            {
                if (m_Board.GetSquareValue(i, m_Board.Size - i - 1) != sign)
                {
                    isAllDiagTheSameSign = false;
                }
            }

            return isAllDiagTheSameSign;
        }
    }
}
