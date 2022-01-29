using System;
using System.Numerics;

namespace GameLibs
{
    public class player
    {
        public Vector2 position, velocity, gravity;
    }

    


    internal class Program
    {
        public static Vector2 PredictProjectileAtTime(float t, Vector2 v0, Vector2 x0, Vector2 g)
        {
            return g * (0.5f * t * t) + v0 * t + x0;
        }

        static void Main(string[] args)
        {

            #region movement
            /*
            myPoint pPacMan = new();
            pPacMan.X = 1;
            pPacMan.Y = 0;

            myVector vDirection = new();
            vDirection.X = 2;
            vDirection.Y = 3;

            myPoint p2 = pPacMan.AddVector(vDirection);

            Console.WriteLine($"Result. ({p2.X}:{p2.Y})");
            */
            #endregion


            #region Imkie, Clive vector to PacMans Position
            /*
            // Generating starting Positions for PacMan, Imkie and Clive
            Vector2 pointPacMan = new(1, 2);
            Vector2 pointImkie  = new(3, 4);
            Vector2 pointClive  = new(2,-1);
            
            // The Initial Speed from PacMans 0:0 to 1:2 is the length of PosPM
            Console.WriteLine($"PacMan initial Speed {pointPacMan.Length()}");
            //Console.WriteLine($"PacMan looks to {pointImkie.}");

            // If we want to change speed towards faster (doubled) then multiply the Point
            Vector2 doubledPacMan = new();
            doubledPacMan = pointPacMan * 2;
            Console.WriteLine($"PacMan doubled Speed {doubledPacMan.Length()}");

            // If we want to change speed towards slower (halved) then divide the Point
            Vector2 halvedPacMan = new();
            halvedPacMan = pointPacMan / 2;
            Console.WriteLine($"PacMan halved Speed  {halvedPacMan.Length()}\n");

            // The Vektor from Imkie to PacMan is calculated with the Point PM - Imkie
            Vector2 vImkieToPacManDirections = new();        
            vImkieToPacManDirections = pointPacMan - pointImkie;

            // We can Normalize the Vector to max 1 (Hat of PI)
            Vector2 PINormalize = Vector2.Normalize(vImkieToPacManDirections);

            // We use the Distance (and squared) Method of Vector2 to calculate the Distance between 2 Vectors
            Single vImkieToPacManDistance = Vector2.Distance(pointPacMan, pointImkie);
            Single vImkieToPacManDistanceSquared = Vector2.DistanceSquared(pointPacMan, pointImkie);

            //everything also for Clives Information
            Vector2 vCliveToPacManDirections = new();
            vCliveToPacManDirections = pointPacMan - pointClive;
            Vector2 PCNormalize = Vector2.Normalize(vCliveToPacManDirections);
            Single vCliveToPacManDistance = Vector2.Distance(pointPacMan, pointClive);
            Single vCliveToPacManDistanceSquared = Vector2.DistanceSquared(pointPacMan, pointClive);

            // Right Stuff to Console so we see the magic with Vector2
            Console.WriteLine($"Imkie and Clive has to go to PacMan:");
            Console.WriteLine($"PacMan Pos: {pointPacMan.X,3}: {pointPacMan.Y,3}\n");

            Console.WriteLine($"Imkie Pos:  {pointImkie.X,3}: {pointImkie.Y,3}");
            Console.WriteLine($"Imkie Dir:  {vImkieToPacManDirections.X,3}: {vImkieToPacManDirections.Y,3}");
            Console.WriteLine($"The Distance  from Imkie to PacMan is {vImkieToPacManDistance}");
            Console.WriteLine($"The Distance2 from Imkie to PacMan is {vImkieToPacManDistanceSquared}");
            Console.WriteLine($"The normalize from Imkie to PacMan is {PINormalize}");


            Console.WriteLine($"");
            Console.WriteLine($"Clive Pos:  {pointClive.X,3}: {pointClive.Y,3}");
            Console.WriteLine($"Clive Dir:  {vCliveToPacManDirections.X,3}: {vCliveToPacManDirections.Y,3}");
            Console.WriteLine($"The distance  from Clive to PacMan is {vCliveToPacManDistance}");
            Console.WriteLine($"The distance2 from Clive to PacMan is {vCliveToPacManDistanceSquared}");
            Console.WriteLine($"The normalize from Clive to PacMan is {PCNormalize}");

            Console.WriteLine($"");
            // The New Position of Pacman in the direction diagonal is to add the right and down Vectors together
            Vector2 rightPacMan = new(4, 0);
            Vector2 downPacMan   = new(0, -5);
            Vector2 pointPacManNew = rightPacMan + downPacMan;
            Console.WriteLine($"PacMans new Position is {pointPacManNew.X,3}:{pointPacManNew.Y,3}");
            Console.WriteLine();
            */
            #endregion

            #region Backstabbing (relation between two Vector) and other stuff

            // Math Physics Definition
            // |a Vector| * |b Vector| * cos 0
            /*
             *     ^ Vector 2
             *    /
             *   / 
             *  / cos Theta
             * -------> Vector 1
             */

            // Games Definition
            //  ax Vector * bx Vector + ay Vector * byte Vector
            /*
             * Normilized BR direction
             * Normilized View direction of Blue Player
             * 
             * If
             * -------> HAT BR
             * -------> HAT View
             * then 
             * DOT = 1
             * 
             * for example
             * Blue -> Red   looking and position is in front of Blue, no Backstab (DOT=1)
             * 
             * Blue -----> View
             * |
             * | direction
             * |
             * v
             * Red => DOT = 0
             * 
             * Red --direction--> Blue --View--> => DOT = -1
             * 
             */
            /*

            Vector2 bE = new(3, 0); //looking to the right
            Vector2 bEn = Vector2.Normalize(bE);
            Console.WriteLine($"blue Person Enemy View {bEn}");



            //Vector2 rP = new(-1, 0); // Red is behind Blue
            //Vector2 rP = new(3, 1); //Red is above Blue X = 3 as red Y is above 0
            Vector2 rP = new(2, -5); // just made it
            Vector2 rPn = Vector2.Normalize(rP);
            Console.WriteLine($"Red Position {rPn}");



            Vector2 BRdirection = rPn - bEn;
            Console.WriteLine($"BR Direction is {BRdirection}");

            Vector2 BRdirectionNormalized = Vector2.Normalize(BRdirection);
            Console.WriteLine($"BR normalized is {BRdirectionNormalized}");

            Single DOTProduct = Vector2.Dot(bEn, BRdirectionNormalized);
            //Vector2 DOTProductManuall = bluePersonEnemyView * BRdirectionNormalized;

            Console.WriteLine($"DOT = {DOTProduct}");

            if (DOTProduct < -0.5f)
                Console.WriteLine($"BACK Success.");
            else
                Console.WriteLine($"Nope no chance.");


            */
            #endregion

            #region Marios jumping and Gravity

            player mario = new();
            mario.position = new Vector2(0, 0);
            mario.velocity = new Vector2(2, 2);
            mario.gravity = new Vector2(0, -2);

            //for (int i = 1; i < 10; i++)
            //{
            //    float time_0 = (float)i * 1.5f;
            //    float time_1 = (float)i + 1 * 0.5f;
            //    Console.WriteLine($"Predict 0: {PredictProjectileAtTime(time_0, mario.velocity, mario.position, mario.gravity),15:F2} ");
            //    //Console.WriteLine($"Predict 1: {PredictProjectileAtTime(time_1, mario.velocity, mario.position, mario.gravity),15:F2}");
            //}

            DateTime dtPreviousTime;
            DateTime dtCurrentTime = DateTime.Now;

            while (true)
            {
                dtPreviousTime = dtCurrentTime;
                dtCurrentTime = DateTime.Now;

                float flDeltaTime = dtCurrentTime.Ticks - dtPreviousTime.Ticks;
                
                if (flDeltaTime > 1f)
                    flDeltaTime = 1f;
                

                mario.position = mario.position + mario.velocity * flDeltaTime;



/*
                if (mario.position.Y < 0)
                {
                    mario.position.Y = 0;
                    mario.velocity.Y = 2;
                }*/

                mario.velocity = mario.velocity + mario.gravity * flDeltaTime;

                //System.Threading.Thread.Sleep(5);
                Console.WriteLine($"Mario Pos: {mario.position:F2}; Velocity: {mario.velocity:F2}");

                

                if (mario.position.X > 10)
                    break;


            }

            /*
             * 
             * 
             * 
             * */


            

            #endregion

            #region main Programm
            #endregion
        }
    }
}
