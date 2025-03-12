namespace MageSurvivor.Code.Enemies
{
    using UnityEngine;

    public class Enemy
    {
        public static int Count { get; set; }
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void ResetCount() => Count = 0;

        public Enemy()
        {
            Count++;
        }
        
        public void Die()
        {
            Count--;
        }
    }
}