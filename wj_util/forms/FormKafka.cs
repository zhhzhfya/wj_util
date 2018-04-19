using Kafka.Client.Cfg;
using Kafka.Client.Producers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WjUtil.forms
{
    public partial class FormKafka : Form
    {
        public FormKafka()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string bootstraps = this.textBox_zk_connect.Text;
            //if (String.IsNullOrEmpty(bootstraps))
            //{
            //    MessageBox.Show("请输入kafka的bootstrap地址");
            //    return;
            //}
            //if (consumer != null)
            //{
            //    consumer.Dispose();
            //    consumer = null;
            //    this.button_consumer.Text = "接收";
            //    return;
            //}
            //this.button_consumer.Text = "停止";

            //var config = new Config() { GroupId = "simple-csharp-consumer" };
            //using (consumer = new EventConsumer(config, bootstraps))
            //{
            //    consumer.OnMessage += (obj, msg) =>
            //    {
            //        string text = Encoding.UTF8.GetString(msg.Payload, 0, msg.Payload.Length);
            //        this.textBox_kafka_consumer.AppendText(text);
            //        this.textBox_kafka_consumer.ScrollToCaret();
            //    };

            //    consumer.Assign(new List<TopicPartitionOffset> { new TopicPartitionOffset("wj_net", 0, 5) });
            //    consumer.Start();
            //    Console.WriteLine("Started consumer");
            //}

            ////string[] _bootstraps = Regex.Split(bootstraps, ",", RegexOptions.IgnoreCase);
            ////Uri[] uris = new Uri[_bootstraps.Length];
            ////for (int i = 0; i < _bootstraps.Length; i++)
            ////{
            ////    uris[i] = new Uri("http://"+_bootstraps[i]);
            ////}
            ////var options = new KafkaOptions(uris)
            ////{
            ////    Log = new ConsoleLog()
            ////};
            ////router = new BrokerRouter(options);
            //////var client = new Producer(router);

            ////ThreadHelper.RunInAdditionalThread(new DlgtVoidMethod(() =>
            ////{
            ////    // 
            ////    consumer = new Consumer(new ConsumerOptions("wj_net", router));
            ////    foreach (var data in consumer.Consume())
            ////    {
            ////        // ... process each message
            ////        Console.WriteLine(data);
            ////        this.textBox_kafka_consumer.AppendText(data.ToString());
            ////        this.textBox_kafka_consumer.ScrollToCaret();
            ////    }
            ////    Console.WriteLine("kafka consumer end.");
            ////})
            ////, new DlgtVoidMethod_withParam(delegate(Object oEx)
            ////{
            ////    MessageBox.Show((oEx as Exception).Message);
            ////}));
            ////Console.WriteLine("start consumer");
        }
        Producer kafkaProducer;
        private void button_producer_Click(object sender, EventArgs e)
        {
            //string bootstraps = this.textBox_metadata_broker.Text;
            //if (String.IsNullOrEmpty(bootstraps))
            //{
            //    MessageBox.Show("请输入kafka的bootstrap地址");
            //    return;
            //}

            ////using (Producer producer = new Producer(bootstraps))
            ////using (Topic topic = producer.Topic("testtopic"))
            ////{
            ////    byte[] data = Encoding.UTF8.GetBytes("Hello RdKafka");
            ////    Task<DeliveryReport> deliveryReport = topic.Produce(data);
            ////    var unused = deliveryReport.ContinueWith(task =>
            ////    {
            ////        Console.WriteLine(String.Format("Partition: {0}, Offset: {1}", task.Result.Partition, task.Result.Offset));
            ////    });
            ////}
            //List<BrokerConfiguration> brokers = new List<BrokerConfiguration>();
            //string[] _bootstraps = Regex.Split(bootstraps, ",", RegexOptions.IgnoreCase);
            //for (var i = 0; i < _bootstraps.Length; i++)
            //{
            //    string[] hp = Regex.Split(_bootstraps[i], ":", RegexOptions.IgnoreCase);
            //    var brokerConfig = new BrokerConfiguration()
            //    {
            //        BrokerId = 1,
            //        Host = hp[0],
            //        Port = int.Parse(hp[1])
            //    };
            //}

            //var config = new ProducerConfiguration(brokers);
            //kafkaProducer = new Producer(config);
            //// here you construct your batch or a single message object
            //ProducerData<TKey, TData> data = new ProducerData<TKey, TData>();
            //kafkaProducer.Send(batch);

            //Console.WriteLine("producer end ");
        }
    }
}
