using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorLines
{
    internal class Game
    {
        int[,] map; // 0-пусто, 1-6 шарик цвета N
        int max_colors = 6;
        int max;
        ShowItem Show;
        Status status;
        Ball[] ball = new Ball[3];
        static Random random = new Random();
        enum Status
        {
            init,       // начало игры
            wait,       // ожидание выбора 1 шарика
            ball_mark,  // шарик выбран
            path_show,  // показать путь следования шарика
            ball_move,  // процесс перемещения шарика
            next_balls, // вывод подсказки по следующим шарикам
            line_strip, // взрыв собранных линий
            stop        // поле заполнено, конец игры
        }


        public Game(int max, ShowItem Show)
        {
            this.max = max;
            map = new int[max, max];
            this.Show = Show;
            status = Status.init;
        }


        Ball marked_ball;
        int marked_jump;
        public void ClickBox(int x, int y)
        {
            if (status == Status.wait || status == Status.ball_mark)
            {
                if (map[x, y] > 0)
                {
                    if (status == Status.ball_mark)
                    {
                        Show(marked_ball, Item.ball);
                    }
                    marked_ball.x = x;
                    marked_ball.y = y;
                    marked_ball.color = map[x, y];
                    status = Status.ball_mark;
                    marked_jump = 0;
                    return;
                }
            }
        }

        public void Step()
        {
            switch (status)
            {
                case Status.init:
                    SelectNextBalls();
                    ShowNextBalls();
                    SelectNextBalls();
                    status = Status.wait;
                    break;
                case Status.wait:
                    break;
                case Status.ball_mark:
                    JumpBall();
                    break;
                //case Status.path_show:
                //    break;
                case Status.ball_move:
                    MoveBall();
                    break;
                case Status.next_balls:
                    ShowNextBalls();
                    break;
                case Status.line_strip:
                    StripLine();
                    break;
                    //case Status.stop:
                    //    break;
            }
        }

        private void StripLine()
        {
            throw new NotImplementedException();
        }

        private void MoveBall()
        {
            throw new NotImplementedException();
        }

        private void JumpBall()
        {
            if (status != Status.ball_mark) return;
            if (marked_jump == 0)
                Show(marked_ball, Item.jump);
            else
                Show(marked_ball, Item.ball);
            marked_jump = 1 - marked_jump;
        }

        private void ShowNextBalls()
        {
            ShowNextBall(ball[0]);
            ShowNextBall(ball[1]);
            ShowNextBall(ball[2]);
        }
        private void ShowNextBall(Ball next)
        {
            if (next.x < 0) return;
            if (map[next.x, next.y] > 0)
            {
                next = SelectNextBall();
                if (next.x < 0) return;
            }
            map[next.x, next.y] = next.color;
            Show(next, Item.ball);
        }

        private void SelectNextBalls()
        {
            ball[0] = SelectNextBall();
            ball[1] = SelectNextBall();
            ball[2] = SelectNextBall();
        }

        Ball SelectNextBall()
        {
            int loop = 100;
            Ball next;
            next.color = random.Next(1, max_colors + 1);
            do
            {
                next.x = random.Next(0, max);
                next.y = random.Next(0, max);
                if (--loop < 0)
                {
                    next.x = -1;
                    return next;
                }
            } while (map[next.x, next.y] != 0);
            map[next.x, next.y] = -1;
            Show(next, Item.next);
            return next;
        }
    }
}
