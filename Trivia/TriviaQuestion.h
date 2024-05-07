#pragma once

#include <string>
#include <array>
#include <vector>
#include <iostream>

enum TriviaDifficulty
{
	DIFF_INVALID = -1,
	DIFF_ANY,
	EASY,
	MEDIUM,
	HARD
};
enum TriviaCategory
{
	CAT_INVALID = -1,
	CAT_ANY,
	GENERAL_KNOWLEDGE = 9,
	ENTERTAINMENT_BOOKS,
	ENTERTAINMENT_FILM,
	ENTERTAINMENT_MUSIC,
	ENTERTAINMENT_MUSICALS_THEATRES,
	ENTERTAINMENT_TELEVISION,
	ENTERTAINMENT_VIDEO_GAMES,
	ENTERTAINMENT_BOARD_GAMES,
	SCIENCE_NATURE,
	SCIENCE_COMPUTERS,
	SCIENCE_MATHEMATICS,
	MYTHOLOGY,
	SPORTS,
	GEOGRAPHY,
	HISTORY,
	POITICS,
	ART,
	CELEBRITIES,
	ANIMALS,
	VEHICLES,
	ENTERTAINMENT_COMICS,
	SCIENCE_GADGETS,
	ENTERTAINMENT_ANIME_MANGA,
	ENTERTAINMENT_CARTOON_ANIMATIONS
};

class TriviaQuestion
{
public:

	static const int PARAM_AMOUNT_MIN = 1;
	static const int PARAM_AMOUNT_MAX = 20;
	
	TriviaQuestion();
	TriviaQuestion(const TriviaDifficulty df, const TriviaCategory ct, const std::string qu, std::string ca, const std::array<std::string, 3>& inca);
	~TriviaQuestion();

	TriviaDifficulty getDifficulty() const;
	TriviaCategory getCategory() const;
	std::string getQuestion() const;
	std::string getCorrectAnswer() const;
	std::array<std::string, 3> getIncorrectAnswers() const;

	static bool isValid(const TriviaDifficulty df, const TriviaCategory ct);
	static std::string difficultyToString(const TriviaDifficulty df);
	static TriviaDifficulty stringToDifficulty(const std::string str);
	static std::string categoryToString(const TriviaCategory ct);
	static TriviaCategory stringToCategory(const std::string str);

	bool isValid() const;

	friend std::ostream& operator<<(std::ostream& os, const TriviaQuestion& tq);

private:

	TriviaDifficulty _difficulty;
	TriviaCategory _category;
	std::string _question;
	std::string _correctAnswer;
	std::array<std::string, 3> _incorrectAnswers;

	static const std::vector<std::string> _stringCategories;
};