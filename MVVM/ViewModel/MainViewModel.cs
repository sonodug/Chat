using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ChatClientInterface.MVVM.Model;
using ChatClientInterface.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientInterface.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* cmd */
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            { 
                _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            { 
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";
            });

            Messages.Add(new MessageModel
            {
                Username = "mudlo",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/303AWfH.png",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "mudlo",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/303AWfH.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = true
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "huylo",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/303AWfH.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = true
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "huylo",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/303AWfH.png",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"mudlo {i}",
                    ImageSource = "https://i.imgur.com/bQwXTzr.jpeg",
                    Messages = Messages
                });
            }
        }
    }
}
