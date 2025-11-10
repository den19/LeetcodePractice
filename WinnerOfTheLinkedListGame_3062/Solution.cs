namespace WinnerOfTheLinkedListGame_3062
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        /// <summary>
        /// O(n)
        /// O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int GameResultLinear(ListNode head)
        {
            int player1Score = 0;
            int player2Score = 0;
            ListNode current = head;
            bool isPlayer1Turn = true;

            while (current != null)
            {
                if (isPlayer1Turn)
                {
                    player1Score += current.val;
                }
                else
                {
                    player2Score += current.val;
                }

                current = current.next;
                isPlayer1Turn = !isPlayer1Turn;
            }

            if (player1Score > player2Score)
            {
                return 1;
            }
            else if (player1Score < player2Score)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// O(n)
        /// O(1_
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        int GameResultLinearCleaner(ListNode head)
        {
            int player1 = 0, player2 = 0;
            var current = head;
            int turn = 0; // 0 for player 1, 1 for plater 2

            while (current != null)
            {
                if (turn % 2 == 0)
                {
                    player1 += current.val;
                }
                else
                {
                    player2 += current.val;
                }

                current = current.next;
                turn++;
            }

            return player1 > player2 ? 1 : (player2 > player1 ? 2 : 0);
        }

        /// <summary>
        /// Pair-wise Processing approach
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        int GameResultLinearPairWise(ListNode head)
        {
            int player1 = 0, player2 = 0;
            var current = head;

            // Process nodes in pairs
            while (current != null)
            {
                player1 += current.val;
                player2 += current.next.val;
                current = current.next.next; // Move to next pair
            }

            return player1.CompareTo(player2);
        }
    }
}
