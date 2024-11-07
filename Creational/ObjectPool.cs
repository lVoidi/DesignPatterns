using System;
using System.Collections.Generic;

namespace Creational
{
    // The Reusable class
    public class Reusable
    {
        public void DoWork()
        {
            Console.WriteLine("Reusable object is working.");
        }
    }

    // The Object Pool class
    public class ObjectPool
    {
        private readonly List<Reusable> _available = new List<Reusable>();
        private readonly List<Reusable> _inUse = new List<Reusable>();

        public Reusable AcquireReusable()
        {
            if (_available.Count != 0)
            {
                var reusable = _available[0];
                _inUse.Add(reusable);
                _available.RemoveAt(0);
                return reusable;
            }
            else
            {
                var reusable = new Reusable();
                _inUse.Add(reusable);
                return reusable;
            }
        }

        public void ReleaseReusable(Reusable reusable)
        {
            _inUse.Remove(reusable);
            _available.Add(reusable);
        }
    }

    // Example usage
    class ObjectPoolClient
    {
        static void Main(string[] args)
        {
            ObjectPool pool = new ObjectPool();

            Reusable reusable1 = pool.AcquireReusable();
            reusable1.DoWork();

            Reusable reusable2 = pool.AcquireReusable();
            reusable2.DoWork();

            pool.ReleaseReusable(reusable1);
            pool.ReleaseReusable(reusable2);

            Reusable reusable3 = pool.AcquireReusable();
            reusable3.DoWork();
        }
    }
}