using OPPClassLibrary;

namespace OPPWebApp.Services
{
    public interface IOldPhonePadService
    {
        string ProcessInput(string input);
    }// interface

    public class OPPService : IOldPhonePadService
    {
        public string ProcessInput(string input)
        {
            return OldPhonePad.ProcessOldPhonePad(input);
        }// process input

    }// class

}// namespace
