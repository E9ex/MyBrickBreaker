using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public Ball ball { get; private set; }
   public Paddle paddle { get; private set; }
   public int level = 1;
   public int score = 0;
   public int lives = 3;
   public Brick[] bricks { get; private set; }

   private void Awake()
   {
      DontDestroyOnLoad(this.gameObject);
      SceneManager.sceneLoaded += OnlevelLoaded; //?
   }

   private void Start()
   {
      NewGame();
   }

   private void OnlevelLoaded(Scene scene, LoadSceneMode mode)
   {
      ball = FindObjectOfType<Ball>();
      paddle = FindObjectOfType<Paddle>();
      bricks = FindObjectsOfType<Brick>();

   }

   private void NewGame()
   {
      score = 0;
      lives = 3;
      LoadLevel(1);

   }

   private void LoadLevel(int _level)
   {
      level = _level;
      if (level>2)
      {
         SceneManager.LoadScene("Level2");//winscreen
      }
      else
      {
         SceneManager.LoadScene("Level" + level);

      }
      
   }

   public void hit(Brick brick)
   {
      score += brick.points;
      if (cleared())
      {
         LoadLevel(level + 1);
      }
   }

   public void miss()
   {
      lives--;
      if (lives > 0)
      {
         resetlevel();
      }
      else
      {
         Gameover();
      }
   }

   public void resetlevel()
   {
      ball.resetball();
      paddle.resetpaddle();
      for (int i = 0; i < bricks.Length; i++)
      {
         bricks[i].resetbrick();
      }
   }

   public void Gameover()
   {
      //SceneManager.LoadScene("Gameover");
      NewGame();
   }

   private bool cleared()
   {
      for (int i = 0; i < bricks.Length; i++)
      {
         if (bricks[i].gameObject.activeInHierarchy&& !this.bricks[i].unbreakable)
         {
            return false;
         }
      }

      return true;
   }
}


