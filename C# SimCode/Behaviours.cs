
        #region Data Members

        private float mFacingDirection;				// Direction the fish is facing (1: right; -1: left).
        private float mFacingDirectionX;         	
        private float mFacingDirectionY;
        private float mSpeed = 3;               //Speed that the fish is moving on the X axis
        private float vSpeed = 3;				//Speed that the fish is moving on the Y axis
        private int turns = 0;					//Stores the amount of turns the fish has done
        bool rangen = true;						
        bool dash = true;
        bool accel = true;
        bool sink = true;
        bool time = true;
        bool square = true;
        bool hori = true;
        float distance = 0;						//Stores the distance the token has moved
        int randomNumber = 0;					//Store a random number when given it
        int randomNumber1 = 0;
        int randomNum = 0;
		int starttime = 0;						//Stores the start time of a specific behavior
        int endtime = 0;						//Stores the end time of a specific behavior
        int currenttime = 0;          			//Stores the Current time of a specific behavior
        float xPos = 0;							//Stores the X Position of the token
        float yPos = 0;							//Stores the X Position of the token
        bool follow = true;

        #endregion

        #region Properties

        #region Constructors

        public OrangeFishMind(X2DToken pToken)
        {
            
            this.Possess(pToken);       // Possess token.
            mFacingDirection = 1;       // Current direction the fish is facing.
            mFacingDirectionX = 0;
            mFacingDirectionY = 0;
                
            
        }

        #endregion

        #region Methods

        public void BehaviourGenerater()
        {
            

            if (rangen == true)
            {
                Random random = new Random();
                randomNumber = random.Next(0, 100);
            }

            if (randomNumber == 1)
            {
                DashBehaviour();
            }
            if (randomNumber == 2)
            {
                AccelerationBehaviour();
            }
            if (randomNumber == 3)
            {
                HungryBehaviour();
            }
            if (randomNumber == 4)
            {
                SinkBehaviour();
            }
                
            

        }

        public void DashBehaviour()
        {
            if (dash == true)
            {
                mSpeed = mSpeed + 10;
                dash = false;
                rangen = false;
            }
            
            distance = distance + mSpeed;
            
            if (distance >= 250)
            {
                dash = true;
                mSpeed = 1;
                distance = 0;
                rangen = true;
            }
            
            

        } 
        
        public void AccelerationBehaviour()
            {
                currenttime = DateTime.Now.Second + DateTime.Now.Minute * 60;
                if (time == true)
                {
                    starttime = currenttime;
                    endtime = starttime + 15;
                    time = false;
                }

                if (accel == true)
                {
                    mSpeed = mSpeed + 0.1f;
                }

                if (mSpeed >= 11)
                {
                    rangen = false;
                    accel = false;    
                }
                if (currenttime >= endtime)
                {   
                mSpeed = mSpeed - 0.1f;    
                }
               
      
                if (mSpeed < 1)
               {
                    mSpeed = 1;
                    rangen = true;
                    accel = true;
                    time = true;
               }

            }

        public void HungryBehaviour()
            {
                currenttime = DateTime.Now.Second + DateTime.Now.Minute * 60;
            
                Vector3 tokenPosition = this.PossessedToken.Position;
                this.PossessedToken.Position = tokenPosition;
                if (time == true)
                {
                    starttime = currenttime;
                    endtime = starttime + 5;
                    time = false;
                    rangen = false;
                }
                
                if (tokenPosition.X <= -150 || tokenPosition.X >= 150)
                {
                    mFacingDirection = mFacingDirection * -1;
                                        
                }
                
                if (tokenPosition.Y >= 250)
                {
                    HorizontalSwimBehaviour();
                }
                else VerticalSwimBehaviour();
                if (turns == 2 ||currenttime >= endtime)
                {
                    time = true;
                    rangen = true;
                    turns = 0;
                }
                          
            }

        public void SinkBehaviour()
            {

               Random random = new Random();
               randomNumber1 = random.Next(49, 151);

               Vector3 tokenPosition = this.PossessedToken.Position;
               this.PossessedToken.Position = tokenPosition;

                if (sink == true)
                {
                    rangen = false;
                    VerticalSwimBehaviour();
                    vSpeed = -1;
                    
                }
                if (tokenPosition.Y <= -randomNumber1)
                {
                    sink = false;
                    HorizontalSwimBehaviour();
                    vSpeed = 1;
                    
                }

                if (turns == 1)
                {
                    rangen = true;
                    sink = true;
                }
                turns = 0;
            }
         
        public void HorizontalSwimBehaviour()
        
        {
            Vector3 tokenPosition = this.PossessedToken.Position;
            tokenPosition.X = tokenPosition.X + mSpeed*mFacingDirection;
            this.PossessedToken.Position = tokenPosition;

            this.PossessedToken.Orientation = new Vector3(mFacingDirection,
            this.PossessedToken.Orientation.Y,
            this.PossessedToken.Orientation.Z);

           

            if (tokenPosition.X <= -400 || tokenPosition.X >= 400)
            {
                mFacingDirection = mFacingDirection * -1;   //Changes direction the orange fish is moving.
                //mSpeed = mSpeed + 1;                        //Changes the speed of the fishtoken after ever turn.
                turns = turns + 1;
            }
                
              
           /* if (turns >= 3 )
            {
                mSpeed = 0;                                 //stops the fish when it reaches 3 turns.
            } */
            }
        
        public void VerticalSwimBehaviour()
            
            {

                Vector3 tokenPosition = this.PossessedToken.Position;			//Stores the tokens position
                tokenPosition.Y = tokenPosition.Y + vSpeed * mFacingDirection;	//Makes the fish move by adding the speed times by the facing direction
                this.PossessedToken.Position = tokenPosition;					//Pass the tokens position back

                this.PossessedToken.Orientation = new Vector3(mFacingDirection,	//Sets the orientation of the token
                this.PossessedToken.Orientation.Y,
                this.PossessedToken.Orientation.Z);

            if (tokenPosition.Y <= -250 || tokenPosition.Y >= 250 )				//Checks to see if the token reaches the side of the screen
            {
                mFacingDirection = mFacingDirection * -1;   //Changes direction the orange fish is moving.
                //mSpeed = mSpeed + 3;                        //Changes the speed of the fishtoken after ever turn.
                turns = turns + 1;							//Adds 1 to the turns variable
            }
                
              
            /* if (turns >= 3 )
            {
                mSpeed = 0;                                 //stops the fish when it reaches 3 turns.
            }*/
            
            }
        
        public void Squareswim()
        {
            Vector3 tokenPosition = this.PossessedToken.Position;
            this.PossessedToken.Position = tokenPosition;


			
            if (square == true)				//Checks to see if the square boolean is true 
            {
                HorizontalSwimBehaviour();	//Call the method that makes the token move on the X axis

            }
			//A bunch of if statments that check to see if the token has reached a certain point and then changes variable to make the token move in a square pattern.
            if (tokenPosition.X >= 200)
            {
                square = false;
                vSpeed = 1;
                VerticalSwimBehaviour();

            }

            if (tokenPosition.Y >= 200)
            {
                HorizontalSwimBehaviour();
                mSpeed = -1;
            }

            if (tokenPosition.X <= -200)
            {
                VerticalSwimBehaviour();
                vSpeed = -1;

            }

            if (tokenPosition.Y <= -200)
            {
                HorizontalSwimBehaviour();
                mSpeed = 1;
            }
        }
            
        public void SpiralSwim()
            {
                Vector3 tokenPosition = this.PossessedToken.Position;
                tokenPosition.Y = tokenPosition.Y + vSpeed * mFacingDirectionY;
                tokenPosition.X = tokenPosition.X + mSpeed * mFacingDirectionX;
                this.PossessedToken.Position = tokenPosition;

                
                    if (tokenPosition.Y == 200 && tokenPosition.X == -200)
                    {
                        mFacingDirectionY = 0;
                        mFacingDirectionX = 1;
                    }

                    if (tokenPosition.Y >= 200 && tokenPosition.X >= 200)
                    {
                        mFacingDirectionY = -1;
                        mFacingDirectionX = 0;
                    }

                    if (tokenPosition.Y <= -200 && tokenPosition.X >= 200)
                    {
                        mFacingDirectionY = 0;
                        mFacingDirectionX = -1;
                    }

                    if (tokenPosition.Y <= -200 && tokenPosition.X <= -200)
                    {
                        mFacingDirectionY = 1;
                        mFacingDirectionX = 0;
                    }
                

                if (hori)
                {
                    if (tokenPosition.Y <= 0 && tokenPosition.X <= 0)
                    {
                        mFacingDirectionY = 0;
                        mFacingDirectionX = 1;
                        hori = false;
                    }
                }
                if (tokenPosition.X <= -400 || tokenPosition.X >= 400)
                    {
                        mFacingDirectionX = mFacingDirectionX * -1;
                    } 
            }

        public void RandomUpDownLeftRight()
        {
            Random random = new Random();
            randomNum = random.Next(0, 100);
            //randomNum = 1;

            Vector3 tokenPosition = this.PossessedToken.Position;
            tokenPosition.Y = tokenPosition.Y + vSpeed * mFacingDirectionY;
            tokenPosition.X = tokenPosition.X + mSpeed * mFacingDirectionX;
            this.PossessedToken.Position = tokenPosition;

            if (tokenPosition.Y <= -250 || tokenPosition.Y >= 250)
            {
                mFacingDirection = mFacingDirection * -1;
            }

            if (tokenPosition.X <= -400 || tokenPosition.X >= 400)
            {
                mFacingDirection = mFacingDirection * -1;
            }

            if (randomNum == 1)
            {
              
                mFacingDirectionY = 1;
                mFacingDirectionX = 0;
            }

            if (randomNum == 2)
            {
                mFacingDirectionY = -1;
                mFacingDirectionX = 0;
            }
            
            if (randomNum == 3)
            {
               
                mFacingDirectionY = 0;
                mFacingDirectionX = -1;
            }
            if (randomNum == 4)
            {
               
                mFacingDirectionY = 0;
                mFacingDirectionX = 1;
            }
          }
        
        public void RoboFish()
        {
            Random random = new Random();
            randomNum = random.Next(0, 100);
            //randomNum = 1;

            Vector3 tokenPosition = this.PossessedToken.Position;
            tokenPosition.Y = tokenPosition.Y + vSpeed * mFacingDirectionY;
            tokenPosition.X = tokenPosition.X + mSpeed * mFacingDirectionX;
            this.PossessedToken.Position = tokenPosition;

            if (randomNum == 1)
            {

                mFacingDirectionY = 1;
                mFacingDirectionX = 0;
            }

            if (randomNum == 2)
            {
                mFacingDirectionY = -1;
                mFacingDirectionX = 0;
            }

            if (randomNum == 3)
            {

                mFacingDirectionY = 0;
                mFacingDirectionX = -1;
            }
            if (randomNum == 4)
            {

                mFacingDirectionY = 0;
                mFacingDirectionX = 1;
            }
         }

        public void FollowMeFish()
        {
                Vector3 tokenPosition = this.PossessedToken.Position;
                tokenPosition.Y = tokenPosition.Y + vSpeed * mFacingDirectionY;
                tokenPosition.X = tokenPosition.X + mSpeed * mFacingDirectionX;
                this.PossessedToken.Position = tokenPosition;

                
                
            
            mFacingDirectionX = 0;
            mFacingDirectionY = 0;
            
            if(follow == true)
            {
                Random random = new Random();
                xPos = random.Next(-400, 400);
                yPos = random.Next(-250,250);
                follow = false;
            }
            
            if (tokenPosition.X < xPos)
            {
                tokenPosition.X = tokenPosition.X + 0.1f;
            }
            
            if (tokenPosition.X > xPos)
            {
                tokenPosition.X = tokenPosition.X - 0.1f;
            }
            
            if (tokenPosition.Y < yPos)
            {
                tokenPosition.Y = tokenPosition.Y + 0.1f;
            }

            if (tokenPosition.Y > yPos)
            {
                tokenPosition.Y = tokenPosition.Y - 0.1f;
            }
        }


            public float BMI (float pWeight, float pHeight) //A method that contain two float parameters
            {
               float result = pWeight * 703f / pHeight;     //The equation that caculates the result
               return result;                               // Returns the result
                
               
            }

        public override void Update(ref GameTime pGameTime)
        {
            //BehaviourGenerater();
            //HorizontalSwimBehaviour();
            //Squareswim();
            //RandomUpDownLeftRight();
            //RoboFish();
            //SpiralSwim();
            FollowMeFish();
            

            /*float bodyMass =  BMI(2, 129);
                Console.WriteLine(bodyMass);
                
                if (bodyMass > 25)              //This IF checks to see if bodyMass is greater than 25
                {
                    HorizontalSwimBehaviour();
                }
                
                if (bodyMass <= 25)
                {
                    Vector3 tokenPosition = this.PossessedToken.Position;
                    this.PossessedToken.Position = tokenPosition;

                    if (tokenPosition.Y < 150)
                    {
                        VerticalSwimBehaviour();
                    }
                    else HorizontalSwimBehaviour();
                }
            */
              
                /* if (mName == "Jeff")
                 {
                     HorizontalSwimBehaviour();                      //This method  makes the fish move horizontal
                
                
                 }
                 else VerticalSwimBehaviour();                        //This method makes the fish move vertical
                 */
        
            }
        
        
        #endregion
    }
}

   