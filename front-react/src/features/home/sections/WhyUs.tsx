import * as React from 'react';
import Box from "@mui/joy/Box";
import Typography from "@mui/joy/Typography";
import {Divider, Sheet} from "@mui/joy";
import Stack from "@mui/joy/Stack";

export const WhyUs = () => {
    return (
        <section
        >
            <Stack
                direction={'column'}
                justifyContent={'center'}
                alignItems={'center'}
            >
                <Typography
                    level={'h2'}
                    color={'success'}
                    sx={{
                        margin: '1rem'
                    }}
                >Why us?</Typography>
                <Sheet
                    variant={'outlined'}
                    color={'success'}
                    sx={{
                        padding: '2rem',
                        margin: '1rem 0',
                        borderRadius: '8px',
                        // backgroundColor: '#ADC6BB'
                    }}
                >
                    <Stack
                        direction={'row'}
                        justifyContent={'center'}
                        spacing={'2rem'}
                        divider={<Divider/>}


                    >
                        <Box
                            sx={{
                                display: 'flex',
                                flexDirection: 'column',
                                justifyContent: 'center',
                                alignItems: 'center',
                            }}
                        >
                            <Typography level='h3'>Genuine Listings</Typography>
                            <Box>We offer only authentic items and services that can be won at our auction.</Box>
                        </Box>

                        <Box>
                            <Typography level='h3'>Real Payments</Typography>
                            <Box>Your contributions translate into real support for charitable initiatives. Every payment makes
                                a positive impact on the world.</Box>
                        </Box>

                        <Box>
                            <Typography level='h3'>Social Impact</Typography>
                            <Box> Your participation in our auction is an opportunity to join a community that acts for the
                                greater good.</Box>
                        </Box>
                    </Stack>
                </Sheet>

            </Stack>
        </section>
    );
};