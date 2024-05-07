#include "ManagerStatistics.h"

std::map<int, User> topFive(std::vector<User> allUsers) //the user ranking based on: true answers - wrong answers
{
	int count = 5;
	std::map<int, User> mapOfScores;
	std::map<int, User> topUsers;
	for (User user : allUsers) {
		mapOfScores[user.getStats().getRightNum() - user.getStats().getWrongNum()] = user ;
	}
	while (count > 0 && !mapOfScores.empty()) {
		auto it = mapOfScores.begin();
		int maxVal = it->first;
		User maxUser = it->second;

	//	// Find the user with the highest value
		for (const auto& pair : mapOfScores) {
			if (pair.first > maxVal) {
				maxVal = pair.first;
				maxUser = pair.second;
			}
		}

	//	// Add the highest user to the topUsers map
		topUsers[maxVal] = maxUser; 

	//	// Remove the highest user from the userValues map
		mapOfScores.erase(maxVal);

		--count;
	}
	return topUsers;
}
