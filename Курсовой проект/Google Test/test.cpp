#include "pch.h"


class ProjectTest :public::testing::Test {
protected:
	ProjectTest app;
	TForm* form;
	TButton* button4;
	TButton* button9;
	TButton* button8;
	TButton* button7;
	TButton* button5;

	virtual void SetUp() {
		form = new TForm(NULL);
		button4 = dynamic_cast<TButton*>(form->FindComponent("N4Button"));
		button9 = dynamic_cast<TButton*>(form->FindComponent("N9Button"));
		button8 = dynamic_cast<TButton*>(form->FindComponent("N8Button"));
		button7 = dynamic_cast<TButton*>(form->FindComponent("N7Button"));
		button5 = dynamic_cast<TButton*>(form->FindComponent("N5Button"));
	}

	virtual void TearDown() {
		form->Free();
	}
};


TEST_F(ProjectTest, TestN4ButtonClick) {
	button4->Click();

	EXPECT_EQ(form->Label1->Caption, "Button N4 clicked");
}

TEST_F(ProjectTest, TestN9ButtonClick) {
	button9->Click();

	EXPECT_EQ(form->Label1->Caption, "Button N9 clicked");
}

TEST_F(ProjectTest, TestN8ButtonClick) {
	button8->Click();

	EXPECT_EQ(form->Label1->Caption, "Button N8 clicked");
}

TEST_F(ProjectTest, TestN7ButtonClick) {
	button7->Click();

	EXPECT_EQ(form->Label1->Caption, "Button N7 clicked");
}

TEST_F(ProjectTest, TestN5ButtonClick) {
	button5->Click();

	EXPECT_EQ(form->Label1->Caption, "Button N5 clicked");
}

