using static System.Net.Mime.MediaTypeNames;

namespace _20250806
{
    // 클래스 형식변환

    class Player
    {
        public int hp;
        public int atk;

        public void Attack()
        {

        }
    }

    // [Player]
    // [Knight]

    class Knight : Player
    {

    }

    class Mage : Player
    {
        public int mp;
    }

    class Program2
    {
        static void EnterGame(Player player)
        {
            Mage mage2 = (Mage)player;
            bool isMage = (player is Mage);
            if (isMage == true)
            {
                mage2 = (Mage)mage2;
                mage2.mp = 10;
            }

            int a = 10;
            Mage mage = (player as Mage); //(Mage)player
            if (mage != null)
            {
                mage.mp = 10;
            }
        }

        static void Main()
        {
            Knight knight = new Knight();
            Mage mage = new Mage();

            knight = null;
            // 가비지컬랙터 

            Player magePlayer = mage;
            Mage mage2 = (Mage)magePlayer;

            EnterGame(knight);
        }
    }
}


/*
   is 연산자는 형변환을 시도하고, 실패하면 null을 반환한다. (O / X)

    as 연산자는 타입이 맞는지 확인하여 true 또는 false를 반환한다. (O / X)
 */

Random rand = new Random();
rand.Next(0, 3);// 0 ~ 2