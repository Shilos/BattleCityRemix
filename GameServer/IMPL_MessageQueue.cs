using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Threading;

namespace Tanki
{
    class IMPL_MessageQueue
    {
    }


    public class MessageQueue : IDisposable where T : class
    {
        private MessageQueue() { }
        public MessageQueue(IServerEngine withEngine, Object data = null)
        {
            _serverEngine = withEngine;
        }

        private Object _locker = new Object();
        private Object _locker_stopping = new Object();
        private AutoResetEvent _ifReady = new AutoResetEvent(false);
        private AutoResetEvent _proceedMsg = new AutoResetEvent(false);
        private AutoResetEvent _timer = new AutoResetEvent(false);

        //private MAK_MSG_proceed_method<T> _msg_proceed_method;
        IServerEngine _serverEngine;
        private Queue<IProtocol> _msg_queue = new Queue<IProtocol>();
        private Thread _proceedingThread = null;
        private Boolean _enforceCancel = false;

        //public MAK_MSG_proceed_method<T> MsgProceedMethod { get { return _msg_proceed_method; } }
        public Thread ProceedingThread { get { return _proceedingThread; } }
        public Boolean EnforceCancel { get { return _enforceCancel; } set { _enforceCancel = value; } }

        public void Enqueue(IProtocol newMsg)
        {
            lock (_locker)
            {
                _msg_queue.Enqueue(newMsg);

                var s = _proceedingThread.ThreadState;
                _ifReady.Set();
            }
        }

        public void RUN()
        {
            _proceedingThread = new Thread(ProceedQueueOneByOne);
            _proceedingThread.Name = "SERVER_MSG_PROCEEDING";
            _proceedingThread.Start();
        }

        private void ProceedQueueOneByOne()
        {
            while (true)
            {
                IProtocol msg = null;

                lock (_locker)
                {
                    if (_enforceCancel)
                        return;

                    if (_msg_queue.Count > 0)
                        msg = _msg_queue.Dequeue();
                }

                if (msg != null)
                {
                    //_serverEngine.ProcessMessage(msg); - НУЖНА ЕЩЕ РЕАЛИЗАЦИЯ ProcessMessage  c параметром 'просто единичный IProtocol'
                }
                else
                    _ifReady.WaitOne();

            }



            //_proceedMsg.Set();
        }


        private void ProceedQueueByTimer()
        {
            while (true)
            {
                IProtocol msg = null;

                lock (_locker)
                {
                    if (_enforceCancel)
                        return;

                    //это будет на callback timera
                    //if (_msg_queue.Count > 0)
                    //    msg = _msg_queue.Dequeue();
                }

                if (msg != null)
                {
                    //_serverEngine.ProcessMessage(msg); - НУЖНА ЕЩЕ РЕАЛИЗАЦИЯ ProcessMessage  c параметром 'просто единичный IProtocol'
                    _timer.WaitOne();
                }
                else
                    _ifReady.WaitOne();

            }



            //_proceedMsg.Set();
        }



        public void Dispose()
        {
            lock (_locker_stopping)
            {
                _enforceCancel = true;
                _proceedingThread.Join();

                _ifReady.Close();
                _ifReady.Dispose();
                _proceedMsg.Close();
                _proceedMsg.Dispose();
                _msg_queue = null;
            }
        }
    }



    public class MessageQueueProcessedByTimer : IDisposable where T : class
    {
        private MessageQueueProcessedByTimer() { }
        public MessageQueueProcessedByTimer(IServerEngine withEngine, Object data = null)
        {
            _serverEngine = withEngine;
        }

        private Object _locker = new Object();
        private Object _locker_stopping = new Object();
        private AutoResetEvent _ifReady = new AutoResetEvent(false);
        private AutoResetEvent _proceedMsg = new AutoResetEvent(false);
        //private AutoResetEvent _timer = new AutoResetEvent(false);

        //private MAK_MSG_proceed_method<T> _msg_proceed_method;
        IServerEngine _serverEngine;
        private Queue<IProtocol> _msg_queue = new Queue<IProtocol>();
        private Thread _proceedingThread = null;
        private Boolean _enforceCancel = false;

        //public MAK_MSG_proceed_method<T> MsgProceedMethod { get { return _msg_proceed_method; } }
        public Thread ProceedingThread { get { return _proceedingThread; } }
        public Boolean EnforceCancel { get { return _enforceCancel; } set { _enforceCancel = value; } }

        private Timer _timer;

        public void Enqueue(IProtocol newMsg)
        {
            lock (_locker)
            {
                _msg_queue.Enqueue(newMsg);

                var s = _proceedingThread.ThreadState;
                //_ifReady.Set();
            }
        }

        public void RUN()
        {
            //_proceedingThread = new Thread(ProceedQueue);
            //_proceedingThread.Name = "SERVER_MSG_PROCEEDING";
            //_proceedingThread.Start();
            _timer = new Timer(ProceedQueue,_ifReady, 0, 1000);

        }

        private void ProceedQueue(Object state)
        {
            while (true)
            {
                IProtocol msg = null;

                lock (_locker)
                {
                    if (_enforceCancel)
                        return;

                    if (_msg_queue.Count > 0)
                        msg = _msg_queue.Dequeue();
                }

                if (msg != null)
                {
                    //_serverEngine.ProcessMessage(msg); - НУЖНА ЕЩЕ РЕАЛИЗАЦИЯ ProcessMessage  c параметром 'просто единичный IProtocol'
                }
                else
                    _ifReady.WaitOne();

            }

            //_proceedMsg.Set();
        }


        public void Dispose()
        {
            lock (_locker_stopping)
            {
                _enforceCancel = true;
                _proceedingThread.Join();

                _ifReady.Close();
                _ifReady.Dispose();
                _proceedMsg.Close();
                _proceedMsg.Dispose();
                _msg_queue = null;
            }
        }
    }





}
