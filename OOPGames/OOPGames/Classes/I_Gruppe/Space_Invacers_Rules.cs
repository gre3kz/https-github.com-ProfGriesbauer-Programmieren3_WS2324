﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace OOPGames
{
    public class Space_Invaders_Rules : II_RulesSpaceIn
    {
        Game_Field I_Field = new Game_Field();
        public string Name { get { return "Space_Invaders_Rules"; } }

        public IGameField CurrentField
        {
            get { return I_Field; }
        }

        public bool MovesPossible
        {
            get { return true; }
        }

        public int CheckIfPLayerWon()
        {
            return -1;
        }

        public void ClearField()
        {
            
        }

        public void DoMove(IPlayMove move)
        {
            if (move is II_SpaceShipMove)
            {
                DoSpaceMove((II_SpaceShipMove)move);
            }
        }

        

        public void StartedGameCall()
        {
        
        }

        public void TickGameCall()
        {
            I_Field.Komet_1.Komet_Move();
            
        }
        public void Ship_Move(IPlayMove move)
        {
            
        }

        public void DoSpaceMove(II_SpaceShipMove move)
        {
            I_Field.Ship_1.Position = I_Field.Ship_1.Position + move.Column;

        }
    }

    public class Game_Field : IGameField
    {
        public bool CanBePaintedBy(IPaintGame painter)
        {
            if (painter is I_Space_Invader_Painter) 
            {
                return true;
            }
            else { return false; }
        }
        //intitialiesiert Komet und Raumschiff
        Komet _Komet_1 = new Komet();
        public Komet Komet_1 { get { return _Komet_1; } }

        Ship _Ship_1 = new Ship();
        public Ship Ship_1 { get { return _Ship_1; } }

        Background _Background = new Background(0, 0, 400, 600, 0);
        public Background Background { get { return _Background; } }

        Background _Background_u = new Background(600, 0, 400, 50, 1);
        public Background Background_u { get { return _Background_u; } }

        Background _Background_rest = new Background(0, 0, 1000, 1000, 2);
        public Background Background_rest { get { return _Background_rest; } }

    }

    public class Komet : II_Komet
    {
        int y_pos = 20;
        int x_pos = 20;
        static int Geschwindigkeit = 1;

        public void Komet_Paint(Canvas canvas)
        {
            //zeichnet Kreis
            Ellipse Komet = new Ellipse();
            Komet.Width = 16; // Durchmesser von 16 Pixeln
            Komet.Height = 16; // Durchmesser von 16 Pixeln
            Komet.Fill = Brushes.Gray;
            canvas.Children.Add(Komet);

            //Setzt den Kreis auf Position
            Canvas.SetTop(Komet, y_pos);
            Canvas.SetLeft(Komet, x_pos);

        }

        //bewegt Komet um Geschwindikeit nach unten
        public void Komet_Move()
        {
            y_pos += Geschwindigkeit;
        }
    }

    public class Ship 
    {
        int y_pos = 400;
        int x_pos = 20;
        int _Move= 0;
        static int Geschwindigkeit = 25;

        public int Position { get { return x_pos; } set { x_pos = value; } }
        public int Move { set { _Move = value; } }


        public void Ship_Paint(Canvas canvas)
        {
            //zeichnet Rechteck
            Rectangle Ship = new Rectangle();
            Ship.Width = 25; // Durchmesser von 16 Pixeln
            Ship.Height = 25; // Durchmesser von 16 Pixeln
            Ship.Fill = Brushes.Blue;
            canvas.Children.Add(Ship);


            //Setzt den Kreis auf Position
            Canvas.SetTop(Ship, y_pos);
            Canvas.SetLeft(Ship, x_pos);

        }


    }

    public class Background
    {
        int _y_pos = 0;
        int _x_pos = 0;
        int _width = 0;
        int _height = 0;
        int _color = 0;

        public Background(int y_pos, int x_pos, int width, int Height, int Color)
        {
            _y_pos = y_pos;
            _y_pos = y_pos;
            _width = width;
            _height = Height;
            _color = Color;
        }
        public void Background_Paint(Canvas canvas)
        {
            //zeichnet rechteck
            Rectangle Background = new Rectangle();
            Background.Width = _width; // Durchmesser von 16 Pixeln
            Background.Height = _height; // Durchmesser von 16 Pixeln
            if (_color == 0) { Background.Fill = Brushes.Black; }
            else {
                if (_color == 1)
                {
                    Background.Fill = Brushes.Blue;
                }
                else
                {
                    Background.Fill = Brushes.Pink;
                }
            }

            canvas.Children.Add(Background);


            //Setzt den Kreis auf Position
            Canvas.SetTop(Background, _y_pos);
            Canvas.SetLeft(Background, _x_pos);

        }
    }


    public class hit
    {

    }
}
