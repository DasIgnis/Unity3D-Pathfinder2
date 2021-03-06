﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BaseAI
{

    /*        x  y  z    angle    time
  current     9  3  1    (0,0,1)   0.5
              9  3  1.2   (0,0,1)   0.5
              9.1  3  1.1    (0,0.1,1)   0.5
              8.9  3  0.1    (0,-0.1,1)   0.5
              
              9  3  1    (0,0,1)   0.7

    */
    /// <summary>
    /// Точка пути - изменяем по сравенению с предыдущим проектом
    /// </summary>
    public class PathNode//: MonoBehaviour
    {
        public Vector3 Position { get; }         //  Позиция в глобальных координатах
        public Vector3 Direction { get; }        //  Направление
        public float TimeMoment { get; set; }         //  Момент времени        
        /// <summary>
        /// Родительская вершина - предшествующая текущей в пути от начальной к целевой
        /// </summary>
        private PathNode Parent { get; } = null;       //  Родительский узел

        public float G { get; }  //  Пройденный путь от цели
        public float H { get; }  //  Пройденный путь от цели

        /// <summary>
        /// Конструирование вершины на основе родительской (если она указана)
        /// </summary>
        /// <param name="ParentNode">Если существует родительская вершина, то её указываем</param>
        public PathNode(PathNode ParentNode = null)
        {
            Parent = ParentNode;
        }

        /// <summary>
        /// Конструирование вершины на основе родительской (если она указана)
        /// </summary>
        /// <param name="ParentNode">Если существует родительская вершина, то её указываем</param>
        public PathNode(Vector3 currentPosition)
        {
            Position = currentPosition;      //  Позицию задаём
            Direction = Vector3.zero;        //  Направление отсутствует
            TimeMoment = -1.0f;              //  Время отрицательное
            Parent = null;                   //  Родителя нет
            G = 0;
            H = 0;
        }

        /// <summary>
        /// Расстояние между точками без учёта времени. Со временем - отдельная история
        /// Если мы рассматриваем расстояние до целевой вершины, то непонятно как учитывать время
        /// </summary>
        /// <param name="other">Точка, до которой высчитываем расстояние</param>
        /// <returns></returns>
        public float Distance(PathNode other)
        {
            return Vector3.Distance(Position, other.Position);
        }

        /// <summary>
        /// Расстояние между точками без учёта времени. Со временем - отдельная история
        /// Если мы рассматриваем расстояние до целевой вершины, то непонятно как учитывать время
        /// </summary>
        /// <param name="other">Точка, до которой высчитываем расстояние</param>
        /// <returns></returns>
        public float Distance(Vector3 other)
        {
            return Vector3.Distance(Position, other);
        }



    }
}