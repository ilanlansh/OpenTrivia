#include "User.h"

#include <iomanip>
#include <sstream>

User::User(const std::string name, const UserStatistics& stats) : _name(name), _stats(stats)
{

}

User::User(const std::string name) : User(name, UserStatistics())
{

}

User::User(const User& other) : User(other._name, other._stats)
{

}

User::User()
{

}

std::string User::getName() const
{
    return this->_name;
}

UserStatistics User::getStats() const
{
    return this->_stats;
}

std::string User::toString() const
{
    return (std::stringstream() << *this).str();
}

std::ostream& operator<<(std::ostream& os, const User& user)
{
    return os << "Name: " << user._name << std::endl <<
        "Stats: " << std::endl << user._stats;
}
