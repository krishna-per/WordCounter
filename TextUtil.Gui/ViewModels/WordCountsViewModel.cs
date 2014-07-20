using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using TextUtil.Factory;
using TextUtil.Interfaces;

namespace TextUtil.Gui.ViewModels
{
    public class WordCountsViewModel : ViewModelBase
    {
        private List<string> _strategies;
        private ICommand _getWordCountsCommand;
        private ObservableCollection<WordCount> _wordCounts;
        private string _strategy;
        private string _text;

        // Text property stores the sentence entered by the user
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnProperytyChanged("Text");
            }
        }

        // Strategy property stores the splitter strategy selected by the user
        public string Strategy
        {
            get { return _strategy; }
            set
            {
                _strategy = value;
                OnProperytyChanged("Strategy");
            }
        }

        // WordCounts property stores the results of word counting
        public ObservableCollection<WordCount> WordCounts
        {
            get
            {
                return _wordCounts;
            }
            private set
            {
                _wordCounts = value; 
                OnProperytyChanged("WordCounts");
            }
        }

        // Strategies gives the list of supported strategies to fill in the strategies combobox
        public List<string> Strategies
        {
            get {
                return _strategies ??
                       (_strategies = new List<string> {"StringSplitter", "RegexSplitter", "ParseSplitter"});
            }
        }

        // GetWordCountsCommand for the Get Word Counts button
        public ICommand GetWordCountsCommand
        {
            get { return _getWordCountsCommand ?? (_getWordCountsCommand = new RelayCommand(param => GetWordCounts())); }
        }

        public WordCountsViewModel()
        {
            // Set default values
            Strategy = "StringSplitter";
            Text = "This is a statement, and so is this.";
        }

        private void GetWordCounts()
        {
            try
            {
                // Based on the selected strategy, create corresponding splitter
                var splitter = Unity.Container.Resolve<ITextSplitter>(Strategy);

                // Create word counter object passing the splitter
                var wordCounter = Unity.Container.Resolve<IWordCounter>(new DependencyOverride<ITextSplitter>(splitter));

                // invoke the GetWordCounts
                var wordCounts = wordCounter.GetWordCounts(Text);

                // Set the results - which will automatically update the UI listview
                WordCounts = new ObservableCollection<WordCount>(wordCounts);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString()); // messagebox is ui element. shouldn't use it directly here in the viewmodel, but will do for now.
            }
            
        }
    }
}