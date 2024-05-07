#include "TriviaQuestion.h"

#include "TriviaExceptions.h"

const std::vector<std::string> TriviaQuestion::_stringCategories =
{
	"", "", "", "", "", "", "", "", "",
	"General Knowledge",
	"Entertainment: Books",
	"Entertainment: Film",
	"Entertainment: Music",
	"Entertainment: Musicals & Theatres",
	"Entertainment: Television",
	"Entertainment: Video Games",
	"Entertainment: Board Games",
	"Science & Nature",
	"Science: Computers",
	"Science: Mathematics",
	"Mythology",
	"Sports",
	"Geography",
	"History",
	"Politics",
	"Art",
	"Celebrities",
	"Animals",
	"Vehicles",
	"Entertainment: Comics",
	"Science: Gadgets",
	"Entertainment: Japanese Anime & Manga",
	"Entertainment: Cartoon & Animations",
};

TriviaQuestion::TriviaQuestion() : TriviaQuestion(DIFF_INVALID, CAT_INVALID, "popo", "pipi", {"a", "b", "c"})
{

}

TriviaQuestion::TriviaQuestion(
	const TriviaDifficulty df, const TriviaCategory ct, const std::string qu, std::string ca, const std::array<std::string, 3>& inca
)
	: _difficulty(df), _category(ct), _question(qu), _correctAnswer(ca), _incorrectAnswers(inca)
{

}

TriviaQuestion::~TriviaQuestion()
{

}

TriviaDifficulty TriviaQuestion::getDifficulty() const
{
	return this->_difficulty;
}

TriviaCategory TriviaQuestion::getCategory() const
{
	return this->_category;
}

std::string TriviaQuestion::getQuestion() const
{
	return this->_question;
}

std::string TriviaQuestion::getCorrectAnswer() const
{
	return this->_correctAnswer;
}

std::array<std::string, 3> TriviaQuestion::getIncorrectAnswers() const
{
	return this->_incorrectAnswers;
}

bool TriviaQuestion::isValid(const TriviaDifficulty df, const TriviaCategory ct)
{
	return df != DIFF_INVALID && ct != CAT_INVALID;
}

std::string TriviaQuestion::difficultyToString(const TriviaDifficulty df)
{
	switch (df)
	{
	case EASY:
		return "easy";
	case MEDIUM:
		return "medium";
	case HARD:
		return "hard";
	default:
		throw TriviaInvalidArgument("Difficulty value " + std::to_string((int)df) + " is invalid");
	}
}

TriviaCategory TriviaQuestion::stringToCategory(const std::string str)
{
	for (int i = 0; i < _stringCategories.size(); i++)
	{
		if (_stringCategories[i] == str)
		{
			return (TriviaCategory)i;
		}
	}

	return CAT_INVALID;
}

TriviaDifficulty TriviaQuestion::stringToDifficulty(const std::string str)
{
	if      (str == "easy")   return EASY;
	else if (str == "medium") return MEDIUM;
	else if (str == "hard")   return HARD;
	else                      return DIFF_INVALID;
}

std::string TriviaQuestion::categoryToString(const TriviaCategory ct)
{
	if (!isValid(DIFF_ANY, ct))
	{
		throw TriviaInvalidArgument("Invalid category " + std::to_string(ct));
	}
	return _stringCategories[(int)ct];
}

bool TriviaQuestion::isValid() const
{
	return isValid(this->_difficulty, this->_category);
}

std::ostream& operator<<(std::ostream& os, const TriviaQuestion& tq)
{
	return os << "Q: " << tq._question <<
		" (C: " << TriviaQuestion::categoryToString(tq._category) <<
		" | D: " << TriviaQuestion::difficultyToString(tq._difficulty) << ")" << std::endl <<
		"  1. " << tq._correctAnswer << " (CORRECT)" << std::endl <<
		"  2. " << tq._incorrectAnswers[0] << std::endl <<
		"  3. " << tq._incorrectAnswers[1] << std::endl <<
		"  4. " << tq._incorrectAnswers[2];
}
