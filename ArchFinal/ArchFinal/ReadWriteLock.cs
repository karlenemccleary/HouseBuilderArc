using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ArchFinal
{
    class ReadWriteLock
    {
        private int waitingForReadLock = 0;
        private int outstandingReadLocks = 0;
        private List<Thread> waitingForWriteLock = new List<Thread>();
        private Thread writeLockedThread;
        public void readLock()
        {
            lock (this)
            {
                if (writeLockedThread != null)
                {
                    waitingForReadLock++;
                    while (writeLockedThread != null)
                    {
                        Monitor.Wait(this);
                    }
                    waitingForReadLock--;
                }
                outstandingReadLocks++;
            }
        }

        public void writeLock()
        {
            Thread thisThread = Thread.CurrentThread;
            lock (this)
            {
                if (writeLockedThread == null && outstandingReadLocks == 0)
                {
                    writeLockedThread = thisThread;
                    return;
                }
                waitingForWriteLock.Add(thisThread);
            }
            lock (thisThread)
            {
                while (thisThread != writeLockedThread)
                {
                    Monitor.Wait(thisThread);
                }
            }

            lock (this)
            {
                waitingForWriteLock.Remove(thisThread);
            }
        }

        public void done()
        {
            lock (this)
            {
                if (outstandingReadLocks > 0)
                {
                    outstandingReadLocks--;
                    if (outstandingReadLocks == 0 && waitingForWriteLock.Count() > 0)
                    {
                        writeLockedThread = (Thread)waitingForWriteLock.ElementAt(0);
                        Monitor.PulseAll(writeLockedThread);
                    }
                }
                else if (Thread.CurrentThread == writeLockedThread)
                {
                    if (waitingForReadLock == 0 && waitingForWriteLock.Count() > 0)
                    {
                        writeLockedThread = (Thread)waitingForWriteLock.ElementAt(0);
                        Monitor.PulseAll(writeLockedThread);
                    }
                    else
                    {
                        writeLockedThread = null;
                        if (waitingForReadLock > 0)
                            Monitor.PulseAll(this);
                    }
                }
                else
                {
                    String msg = "Thread does not have lock";
                    //throw new IllegalStateException(msg);
                }
            }
        }
    }
}
