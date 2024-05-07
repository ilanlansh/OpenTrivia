#include <iostream>
#include "Server.h"
#include "WSAInitializer.h"
#include "WebAccess.h"
#include "TriviaQuestion.h"
#include "TriviaExceptions.h"

constexpr auto TRIVIA_PORT = 6565;

int main()
{
    SetConsoleTitleA("Trivia Console");
    std::cout << "Trivia some version idk anymore" << std::endl;

    try
    {
        WSAInitializer wsaInit;
        Server s;

        s.run(TRIVIA_PORT);
    }
    catch (std::exception& e)
    {
        std::cerr << e.what();
    }
}