package com.mxply.app.baseball.client.droid.model;

import java.util.UUID;

public class MovementDetail {

	public static Class<MovementDetail> MOVEMENTDETAIL_CLASS = MovementDetail.class;
	
	UUID id;
	short number;
	MovementType type;
	Person player;
}
