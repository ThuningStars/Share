#include "Game.hpp"

const float Game::PlayerSpeed = 100.f;
const sf::Time Game::TimePerFrame = sf::seconds(1.f / 60.f);

Game::Game()
	: mWindow(sf::VideoMode(800, 600), "SFML Application", sf::Style::Close)
	, mTexture()
	, mBackground()
	, mAirplaneTexture()
	, mPlayer()
	, mMusic()
	, mFont()
	, mIcon()
	, mStatisticsText()
	, mStatisticsUpdateTime()
	, mStatisticsNumFrames(0)
#pragma region step3
	, mIsMovingUp(false)
	, mIsMovingDown(false)
	, mIsMovingRight(false)
	, mIsMovingLeft(false)

{

	if (!mAirplaneTexture.loadFromFile("Media/Textures/Eagle.png"))
	{
		// Handle loading error
	}

	mPlayer.setTexture(mAirplaneTexture);
	mPlayer.setPosition(100.f, 100.f);


#pragma endregion


	mIcon.loadFromFile("Media/Textures/icon.png");
	mWindow.setIcon(mIcon.getSize().x, mIcon.getSize().y, mIcon.getPixelsPtr());

	//Load a sprite to display
	if (!mTexture.loadFromFile("Media/Textures/cute_image.jpg"))
		return;
	mBackground.setTexture(mTexture);

	if (!mFont.loadFromFile("Media/Sansation.ttf"))
		return;


	mText.setString("Hello SFML");
	mText.setFont(mFont);
	mText.setPosition(5.f, 5.f);
	mText.setCharacterSize(50);
	mText.setFillColor(sf::Color::Black);

	mStatisticsText.setFont(mFont);
	mStatisticsText.setPosition(5.f, 500.f);
	mStatisticsText.setCharacterSize(30);

	mMusic.openFromFile("Media/Sound/nice_music.ogg");
	//Play the music
	//mMusic.play();



}

void Game::run()
{
	sf::Clock clock;
	sf::Time timeSinceLastUpdate = sf::Time::Zero;
	while (mWindow.isOpen())
	{
		sf::Time elapsedTime = clock.restart();
		timeSinceLastUpdate += elapsedTime;
		while (timeSinceLastUpdate > TimePerFrame)
		{
			timeSinceLastUpdate -= TimePerFrame;

			processEvents();
			update(TimePerFrame);
		}

		updateStatistics(elapsedTime);
		render();
	}
}

void Game::processEvents()
{
	sf::Event event;
	while (mWindow.pollEvent(event))
	{
		switch (event.type)
		{

#pragma region step 6 



		case sf::Event::KeyPressed:
			handlePlayerInput(event.key.code, true);
			break;

		case sf::Event::KeyReleased:
			handlePlayerInput(event.key.code, false);
			break;

#pragma endregion

		case sf::Event::Closed:
			mWindow.close();
			break;
		}
	}
}

void Game::update(sf::Time elapsedTime)
{
#pragma region step 5



	sf::Vector2f movement(0.f, 0.f);
	if (mIsMovingUp)
		movement.y -= PlayerSpeed;
	if (mIsMovingDown)
		movement.y += PlayerSpeed;
	if (mIsMovingLeft)
		movement.x -= PlayerSpeed;
	if (mIsMovingRight)
		movement.x += PlayerSpeed;

	mPlayer.move(movement * elapsedTime.asSeconds());

#pragma endregion
}

void Game::render()
{
	//Question: What do you think will it happen if you comment out the following two lines
	mWindow.clear();
	mWindow.draw(mBackground);
	mWindow.draw(mPlayer);
	mWindow.draw(mText);
	mWindow.draw(mStatisticsText);

	//Update the window
	mWindow.display();
}

#pragma region step4

void Game::updateStatistics(sf::Time elapsedTime)
{
	mStatisticsUpdateTime += elapsedTime;
	mStatisticsNumFrames += 1;

	if (mStatisticsUpdateTime >= sf::seconds(1.0f))
	{
		mStatisticsText.setString(
			"Frames / Second = " + std::to_string(mStatisticsNumFrames) + "\n" +
			"Time / Update = " + std::to_string(mStatisticsUpdateTime.asMicroseconds() / mStatisticsNumFrames) + "us");

		mStatisticsUpdateTime -= sf::seconds(1.0f);
		mStatisticsNumFrames = 0;
	}
}


void Game::handlePlayerInput(sf::Keyboard::Key key, bool isPressed)
{
	if (key == sf::Keyboard::W)
		mIsMovingUp = isPressed;
	else if (key == sf::Keyboard::S)
		mIsMovingDown = isPressed;
	else if (key == sf::Keyboard::A)
		mIsMovingLeft = isPressed;
	else if (key == sf::Keyboard::D)
		mIsMovingRight = isPressed;
}

#pragma endregion
