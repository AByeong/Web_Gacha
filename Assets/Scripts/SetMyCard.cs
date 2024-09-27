using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // For Linq operations

public class SetMyCard : MonoBehaviour
{
    GachaManager GM;
    BitArray CardBit;
    public CardInfo[] cardPool;

    private void Awake()
    {
        // Get the string value from GoogleSheetManager
        string bitString = GoogleSheetManager.Instance.GD.value;

        if (string.IsNullOrEmpty(bitString))
        {
            Debug.LogError("bitString from GoogleSheetManager is empty or null!");
            return;
        }

        // Convert the string into a BitArray using the helper function
        CardBit = StringToBitArray(bitString);


       // print($"Bit String: {bitString}");
        print(BitArrayToString(CardBit)); // Show initialized CardBit

        // Proceed with your logic
        for (int i = 0; i < cardPool.Length; i++)
        {
            // Check that the index is within the bounds of the BitArray
            if (i < CardBit.Length)
            {
                // Use a single bit representation for the setter
                BitArray setter = new BitArray(CardBit.Length);
                setter.Set(i, true);

                // Perform bitwise AND with CardBit
                BitArray result = setter.And(CardBit);

                // Print the CardBit and the result BitArray
                print($"CardBit: {BitArrayToString(CardBit)}");
                print($"Setter for index {i}: {BitArrayToString(setter)}");
                print($"Result for index {i}: {BitArrayToString(result)}");

                // Check if the i-th bit in the result is 'true'
                if (result[i])
                {
                    MyChardsManager.Instance.mydeck.Add(cardPool[i]);
                    print($"{MyChardsManager.Instance.mydeck[i].name}¼¼ÆÃ");
                }
               
            }
            else
            {
                Debug.LogWarning($"Card index {i} exceeds the bit array length.");
            }
        }
    }

    // Helper method to convert a string to a BitArray
    private BitArray StringToBitArray(string bitString)
    {
        if (string.IsNullOrEmpty(bitString))
        {
            throw new System.ArgumentException("Input string cannot be null or empty.");
        }

        BitArray bitArray = new BitArray(bitString.Length);
        for (int i = 0; i < bitString.Length; i++)
        {
            bitArray.Set(i, bitString[i] == '1');
        }
        return bitArray;
    }

    // Helper method to convert BitArray to string
    private string BitArrayToString(BitArray bits)
    {
        char[] chars = new char[bits.Count];
        for (int i = 0; i < bits.Count; i++)
        {
            chars[i] = bits[i] ? '1' : '0'; // Convert true to '1', false to '0'
        }

        string Str = new string(chars);
        //print($"Str : {Str}");
        return Str;
    }
}
