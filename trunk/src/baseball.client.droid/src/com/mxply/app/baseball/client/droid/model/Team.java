package com.mxply.app.baseball.client.droid.model;

import java.util.UUID;

public class Team {

	public static Class<Team> TEAM_CLASS = Team.class;
	
	UUID id;
	String name;
	
	Person[] players;
	
}
