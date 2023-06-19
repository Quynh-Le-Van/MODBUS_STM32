/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2023 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */

/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */

/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
UART_HandleTypeDef huart2;

/* USER CODE BEGIN PV */
uint8_t Data_Modbus[4];


/***************************/

uint16_t Start_Adr, End_Adr, Leng_Data;
uint16_t Data[256];
uint8_t Data_Received[256];
uint8_t Data_Send[256];
/******************************/

uint8_t dem = 0;
uint8_t Mang_1[8] = {0x05, 0x03, 0x00, 0x00, 0x00, 0x05};


/**************************/
// Function code: 0x03
static uint16_t Holding_Registers_Database[50]={
		0000,  1111,  2222,  3333,  4444,  5555,  6666,  7777,  8888,  9999,   // 0-9   40001-40010
		12345, 15432, 15535, 10234, 19876, 13579, 10293, 19827, 13456, 14567,  // 10-19 40011-40020
		21345, 22345, 24567, 25678, 26789, 24680, 20394, 29384, 26937, 27654,  // 20-29 40021-40030
		31245, 31456, 34567, 35678, 36789, 37890, 30948, 34958, 35867, 36092,  // 30-39 40031-40040
		45678, 46789, 47890, 41235, 42356, 43567, 40596, 49586, 48765, 41029,  // 40-49 40041-40050
};
// Function code: 0x04
static const uint16_t Input_Registers_Database[50]={
		0000,  1111,  2222,  3333,  4444,  5555,  6666,  7777,  8888,  9999,   // 0-9   30001-30010
		12345, 15432, 15535, 10234, 19876, 13579, 10293, 19827, 13456, 14567,  // 10-19 30011-30020
		21345, 22345, 24567, 25678, 26789, 24680, 20394, 29384, 26937, 27654,  // 20-29 30021-30030
		31245, 31456, 34567, 35678, 36789, 37890, 30948, 34958, 35867, 36092,  // 30-39 30031-30040
		45678, 46789, 47890, 41235, 42356, 43567, 40596, 49586, 48765, 41029,  // 40-49 30041-30050
};

/****************************************/
uint8_t ID_Slave = 0x05;
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_USART2_UART_Init(void);
/* USER CODE BEGIN PFP */

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_USART2_UART_Init();
  /* USER CODE BEGIN 2 */
  uint16_t calculate_crc(uint8_t* Data, size_t Size);
  void Send_data_crc(uint8_t *Data, uint8_t Size);
  uint8_t readHoldingRegs (void);
  uint8_t writeMultRegs (void);
  void HAL_UARTEx_RxEventCallback(UART_HandleTypeDef *huart, uint16_t Size);
  void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart);
  void send_char(char data);



  /**************************/
  HAL_UARTEx_ReceiveToIdle_IT(&huart2, Data_Received, 256);
  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSI;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.HSICalibrationValue = RCC_HSICALIBRATION_DEFAULT;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_NONE;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_HSI;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV1;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_0) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief USART2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART2_UART_Init(void)
{

  /* USER CODE BEGIN USART2_Init 0 */

  /* USER CODE END USART2_Init 0 */

  /* USER CODE BEGIN USART2_Init 1 */

  /* USER CODE END USART2_Init 1 */
  huart2.Instance = USART2;
  huart2.Init.BaudRate = 19200;
  huart2.Init.WordLength = UART_WORDLENGTH_8B;
  huart2.Init.StopBits = UART_STOPBITS_1;
  huart2.Init.Parity = UART_PARITY_NONE;
  huart2.Init.Mode = UART_MODE_TX_RX;
  huart2.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart2.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart2) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART2_Init 2 */

  /* USER CODE END USART2_Init 2 */

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
/* USER CODE BEGIN MX_GPIO_Init_1 */
/* USER CODE END MX_GPIO_Init_1 */

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOA_CLK_ENABLE();

/* USER CODE BEGIN MX_GPIO_Init_2 */
/* USER CODE END MX_GPIO_Init_2 */
}

/* USER CODE BEGIN 4 */
uint16_t calculate_crc(uint8_t* Data, size_t Size)
{
    uint16_t crc = 0xFFFF;
    for (size_t i = 0; i < Size; i++) {
        crc ^= Data[i];
        for (int j = 0; j < 8; j++) {
            if (crc & 0x0001) {
                crc = (crc >> 1) ^ 0xA001;
            } else {
                crc = crc >> 1;
            }
        }
    }
    return crc;
}

//Check CRC
uint8_t check_crc(uint8_t *Data_02, size_t Size)
{
	uint16_t CRC_Check = calculate_crc(Data_02, Size);
	uint16_t Leng = sizeof(Data_02);
	if(  (uint8_t)((CRC_Check >>8) & 0xFF) == Data_02[Leng - 2]  && (uint8_t)(CRC_Check) == Data_02[Leng - 2]  )
	{
		return 1;
	}
	else
	{
		return 0;
	}
}

// Send Data voi CRC
void Send_data_crc(uint8_t *Data, uint8_t Size)
{
    uint16_t Crc = calculate_crc(Data, Size);
    Data[Size + 1] = (uint8_t)(Crc >> 8);
    Data[Size] = (uint8_t)(Crc);
    HAL_UART_Transmit(&huart2, Data, Size + 2, 100);

    for(int j = 0; j < 256; j++)
    {
    	Data[j] = 0x00;
    }
}

// Xu li so lieu voi function code 0x03
uint8_t readHoldingRegs (void)
{
	uint16_t Start_Adr = ((Data_Received[2]<<8)|Data_Received[3]);  // start Register Address

	uint16_t Leng_Data = ((Data_Received[4]<<8)|Data_Received[5]);   // number to registers master has requested
	uint16_t End_Adr = Start_Adr + Leng_Data - 1;  // end Register

//	if ((Leng_Data<1)||(Leng_Data>125))  // maximum no. of Registers as per the PDF
//	{
//		modbusException (ILLEGAL_DATA_VALUE);  // send an exception
//		return 0;
//	}

//	if (End_Adr>49)  // end Register can not be more than 49 as we only have record of 50 Registers in total
//	{
//		modbusException(ILLEGAL_DATA_ADDRESS);   // send an exception
//		return 0;
//	}

	// Prepare TxData buffer

	//| SLAVE_ID | FUNCTION_CODE | BYTE COUNT | DATA      | CRC     |
	//| 1 BYTE   |  1 BYTE       |  1 BYTE    | N*2 BYTES | 2 BYTES |

	Data_Send[0] = ID_Slave;  // slave ID
	Data_Send[1] = Data_Received[1];  // function code
	Data_Send[2] = Leng_Data*2;  // Byte count
	int indx = 3;  // Can 3 vi tri cho 3 o dau tien, Luc sau la so vi tri cua Data

	for (int i=0; i < Leng_Data; i++)
	{
		Data_Send[indx++] = (Holding_Registers_Database[Start_Adr]>>8)&0xFF;  // 8 bit muc cao
		Data_Send[indx++] = (Holding_Registers_Database[Start_Adr])&0xFF;   //  8 bit muc thap
		Start_Adr++;  // increment the register address
	}

	Send_data_crc(Data_Send, indx) ; // send data... CRC will be calculated in the function itself
	return 1;   // success
}

// Xu li so lieu voi function code 0x10
uint8_t writeMultRegs (void)
{
	uint16_t Start_Adr = ((Data_Received[2]<<8)|Data_Received[3]);  // start Register Address

	uint16_t Leng_Data = ((Data_Received[4]<<8)|Data_Received[5]);   // number to registers master has requested
	uint16_t End_Adr = Start_Adr + Leng_Data - 1;  // end Register

//	if ((Leng_Data<1)||(Leng_Data>125))  // maximum no. of Registers as per the PDF
//	{
//		modbusException (ILLEGAL_DATA_VALUE);  // send an exception
//		return 0;
//	}

//	if (End_Adr>49)  // end Register can not be more than 49 as we only have record of 50 Registers in total
//	{
//		modbusException(ILLEGAL_DATA_ADDRESS);   // send an exception
//		return 0;
//	}

	// Prepare TxData buffer

	//| SLAVE_ID | FUNCTION_CODE | BYTE COUNT | DATA      | CRC     |
	//| 1 BYTE   |  1 BYTE       |  1 BYTE    | N*2 BYTES | 2 BYTES |

	Data_Send[0] = ID_Slave;  // slave ID
	Data_Send[1] = 0x10;  // function code
	Data_Send[2] = Data_Received[2];   // Start_Address HIGH
	Data_Send[3] = Data_Received[3];   //  Start_Address LOW
	Data_Send[4] = (uint8_t)((Leng_Data>>8)&0xFF);   // Leng_Data HIGH
	Data_Send[5] = (uint8_t)(Leng_Data & 0xFF);   // Leng_Data LOW

	int indx = 7;  //

	for (int i=0; i < Leng_Data; i++)
	{
		Holding_Registers_Database[Start_Adr] = ((Data_Received[indx] << 8) | Data_Received[indx + 1]); // Hop bit High vs Low
		indx += 2;
		Start_Adr += 1;  // increment the register address
	}

	Send_data_crc(Data_Send, 6) ;
	return 1;   // success
}

void HAL_UARTEx_RxEventCallback(UART_HandleTypeDef *huart, uint16_t Size)
{
	uint8_t true_false_crc = check_crc(Data_Received, sizeof(Data_Received));
	if(true_false_crc == 1)
	{
		if(Data_Received[0] == ID_Slave)   // Check ID
		{
			if(Data_Received[1] == 0x03)    // Check Function code
			{
				readHoldingRegs();
			}
			else if(Data_Received[1] == 0x10)    // Check Function code
			{
				writeMultRegs();
			}
			else
			{
				uint8_t Error_02[50] = "Loi Function code";
				for(int i = 0; i < sizeof(Error_02); i++)
				{
					HAL_UART_Transmit(&huart2, &Error_02[i], sizeof(Error_02[i]), 1000);
				}
			}

		}
		else
		{
			uint8_t Error_01[10] = "Loi ID";
			for(int i = 0; i < sizeof(Error_01); i++)
			{
				HAL_UART_Transmit(&huart2, &Error_01[i], sizeof(Error_01[i]), 1000);
			}
		}
	}

	else
	{
		uint8_t Error_03[10] = "Loi CRC";
		for(int i = 0; i < sizeof(Error_03); i++)
		{
			HAL_UART_Transmit(&huart2, &Error_03[i], sizeof(Error_03[i]), 1000);
		}
	}
	for(int k = 0; k < 256; k ++)
	{
		Data_Received[k] = 0x00;
	}
	  HAL_UARTEx_ReceiveToIdle_IT(&huart2, Data_Received, 256);
}


void send_char(char data){
	while((USART2->SR & (1<<6))==0){}
	USART2->DR = data;
}
/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
