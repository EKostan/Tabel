using System;
using System.Collections.Generic;
using NLog;

namespace CACore.Visualizers
{
    class VisualizerRegistry
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Type - тип IVisualizer
        /// </summary>
        static Dictionary<Type, IVisualizerCreator> plugins = new Dictionary<Type, IVisualizerCreator>();

        public static void RegisterVisualizer(Type visualizerType, IVisualizerCreator visualizerCreator)
        {
            plugins[visualizerType] = visualizerCreator;
            logger.Info("Загрузчик {0} зарегистрирован", visualizerType.FullName);
        }

        public static void RegisterVisualizer(Type visualizerType)
        {
            plugins[visualizerType] = new VisualizerCreator() { VisualizerType = visualizerType };
            logger.Info("Загрузчик {0} зарегистрирован", visualizerType.FullName);
        }

        public static T GetVisualizerCreator<T>(Type visualizerType)
            where T : class, IVisualizerCreator
        {
            return plugins[visualizerType] as T;
        }

        public static T GetVisualizer<T>()
            where T : class, IVisualizer
        {
            var type = typeof (T);
            return plugins[type].Create() as T;
        }

    }
}
