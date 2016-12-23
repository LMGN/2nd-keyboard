-- get luamacros here: http://www.hidmacros.eu/ ... or more accurately, HERE: http://www.hidmacros.eu/forum/viewtopic.php?f=10&t=241#p794
-- plug in your 2nd keyboard, load this script into LUAmacros, and press the triangle PLAY button.
-- Then, press any key on that keyboard to assign logical name ('MASTER') to the main macro keyboard

lmc_assign_keyboard('MASTER'); --COMMENT THIS LINE                               V V V V V V V V
lmc_print_devices(); -- Output will be MASTER : \\?\HID#something&something#B&THISISWHATYOUNEED&0&1337#{CODE-CODE-CODE-CODE-CODE} [NUMBER]: keyboard

lmc_device_set_name('MASTER','2014AF64'); -- Uncomment this line

sendToLM = function (key,file)
      --print('It was assigned string:    ' .. key)
      local file = io.open("C:\\Users\\Leo MG Nesfield\\Downloads\\LooaMacros\\lm\\"..file, "w") -- writing this string to a text file on disk is probably NOT the best method. Feel free to program something better!
      --print("we are inside the text file")
      file:write(key)
      file:flush() --"flush" means "save"
      file:close()
      --lmc_send_keys('{F23}')  -- The program is watching the file instaid of waiting for F23.
end

-- define callback for whole device
lmc_set_handler('MASTER', function(button, direction)

        if direction == 1 then
            --print(' ')
            --print('Your key ID number is:   ' .. button)
            --print('It was assigned string:    ' .. button)
	    --sendToLM("d"..button)
        else

                print(' ')
                print('Your key ID number is:   ' .. button)
                print('It was assigned string:    ' .. button)
	        sendToLM(button,"master.txt")


        end
end)


